using UnityEngine;

public class FindTarget : MonoBehaviour {
    public GameObject enemy;
    public Lane[] lanes;
    public int positionIndex;
    public bool playerControlled = true;
    int myLaneLength;
    int startIndex, endIndex;
    int LaneAttackRange;

    string[] laneNames = new string[] {
        "EnemyMelee",
        "EnemyRange",
        "EnemyCommander",
        "PlayerMelee",
        "PlayerRange",
        "PlayerCommander"
    };
    void Start () {
        lanes = FindObjectsOfType<Lane> ();
    }
    public void UpdateTarget (int positionIndex, int myLaneLength) {
        this.positionIndex = positionIndex;
        this.myLaneLength = myLaneLength;
        LaneSearchIndex ();
        FindNextTarget ();
    }
    public void LaneSearchIndex () {
        if (playerControlled == true) {
            startIndex = 0;
            endIndex = 2;
            LaneAttackRange = GetComponent<Unit> ().AttackRange;
        } else {
            startIndex = 3;
            endIndex = 5;
            LaneAttackRange = GetComponent<Unit> ().AttackRange + 3;
        }
    }
    void FindNextTarget () {
        foreach (Lane lane in lanes) {
            for (int i = startIndex; i <= endIndex; i++) {
                if (lane.name == laneNames[i] && lane.unitsList.Count > 0 && LaneAttackRange >= i) {
                    enemy = FindClosestTargetInLane (lane);
                    break;
                }
            }
            if (enemy != null)
                break;
        }
    }
    GameObject FindClosestTargetInLane (Lane lane) {
        try {
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
        } catch {
            Debug.Log ("Catch");
            return null;
        }

    }
}