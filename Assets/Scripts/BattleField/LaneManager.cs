using UnityEngine;

public class LaneManager : MonoBehaviour {
    [SerializeField] LaneChecker[] playerLanes = new LaneChecker[3];
    [SerializeField] LaneChecker[] enemyLanes = new LaneChecker[3];
    public LaneChecker[] PlayerLanes () {
        return playerLanes;
    }
    public LaneChecker[] EnemyLanes () {
        return enemyLanes;
    }
}