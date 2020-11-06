using System;
using UnityEngine;

[RequireComponent (typeof (Unit))]
public class FindTarget : MonoBehaviour {
    public GameObject enemy;
    public LaneChecker[] attackLanes;
    [SerializeField] AttackManagerSO attackManagerSO;
    [SerializeField] int positionIndex;
    [SerializeField] int myLaneLength;
    LaneChecker myCurrentLane;
    public void Setup (LaneChecker myCurrentLane) {
        this.myCurrentLane = myCurrentLane;
    }
    public void FindNextTarget () {
        if (myCurrentLane == null || !GetComponent<Unit> ().IsAlive)
            return;
        myLaneLength = myCurrentLane.unitsInLane.Count;
        positionIndex = myCurrentLane.unitsInLane.IndexOf (GetComponent<Unit> ());
        enemy = null;
        foreach (LaneChecker lane in attackLanes) {
            if (lane.unitsInLane.Count > 0) {
                enemy = FindClosestTargetInLane (lane);
                break;
            }
        }
    }
    GameObject FindClosestTargetInLane (LaneChecker lane) {

        if (lane.unitsInLane.Count - 1 >= positionIndex) {
            if (positionIndex == 0 && myLaneLength == 1 && lane.unitsInLane.Count == 3) {
                return lane.unitsInLane[1].gameObject;
            } else if (lane.unitsInLane[positionIndex] != null) {
                return lane.unitsInLane[positionIndex].gameObject;
            } else {
                return lane.unitsInLane[lane.unitsInLane.Count - 1].gameObject;
            }
        } else {
            return lane.unitsInLane[lane.unitsInLane.Count - 1].gameObject;
        }
    }
    void FindTargetEvent (AttackManagerSO attackManagerSO) {
        FindNextTarget ();
    }
    void Awake () {
        attackManagerSO.ChangeTargetEvent += FindTargetEvent;
    }
    void OnDestroy () {
        attackManagerSO.ChangeTargetEvent -= FindTargetEvent;
    }
}