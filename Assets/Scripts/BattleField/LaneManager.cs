using UnityEngine;

public class LaneManager : MonoBehaviour {
    public Lane[] attackLanes;
    public Lane[] enemyLanes, playerLanes;

    public void UpdateLanes () {
        foreach (Lane lane in attackLanes) {
            lane.UpdateLane ();
        }
        foreach (Lane attackLane in attackLanes) {
            if (attackLane.unitsList.Count > 0)
                attackLane.UpdateUnitTarget ();
        }
    }
}