using UnityEngine;

[RequireComponent (typeof (Unit))]
public class FindTarget : MonoBehaviour {
    public GameObject enemy;
    public Lane[] attackLanes;
    public bool canAttack = true;
    public int positionIndex;
    int myLaneLength;

    void Start () {
        FindObjectsOfType<Lane> ();
    }
    public void UpdateTarget (int positionIndex, int myLaneLength) {
        this.positionIndex = positionIndex;
        this.myLaneLength = myLaneLength;
        if (canAttack)
            FindNextTarget ();
    }
    void FindNextTarget () {
        foreach (Lane lane in attackLanes) {
            if (lane.unitsList.Count > 0) {
                enemy = FindClosestTargetInLane (lane);
                break;
            }
        }
    }
    GameObject FindClosestTargetInLane (Lane lane) {
        if (lane.unitsList.Count - 1 >= positionIndex) {
            if (positionIndex == 0 && myLaneLength == 1 && lane.unitsList.Count == 3) {
                return lane.unitsList[1].gameObject;
            } else if (lane.unitsList[positionIndex] != null) {
                return lane.unitsList[positionIndex].gameObject;
            } else {
                return lane.unitsList[lane.unitsList.Count - 1].gameObject;
            }
        } else {
            return lane.unitsList[lane.unitsList.Count - 1].gameObject;
        }
    }
}