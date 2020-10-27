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
                if (lane.name == laneNames[i] && lane.units.Length > 0 && LaneAttackRange >= i) {
                    enemy = FindClosestTargetInLane (lane);
                    break;
                }
            }
            if (enemy != null)
                break;
        }
    }
    GameObject FindClosestTargetInLane (Lane lane) {

        if (lane.units.Length - 1 >= positionIndex) {
            if (positionIndex == 0 && myLaneLength == 1 && lane.units.Length == 3) {
                return lane.units[1].gameObject;
            } else if (lane.units[positionIndex] != null) {
                return lane.units[positionIndex].gameObject;
            } else {
                return lane.units[lane.units.Length - 1].gameObject;
            }
        } else {
            return lane.units[lane.units.Length - 1].gameObject;
        }
    }
}