using UnityEngine;

public class LaneManager : MonoBehaviour {
    public Lane[] lanes;
    public Lane[] enemyLanes, playerLanes;

    public void UpdateLanes () {
        foreach (Lane lane in lanes) {
            lane.UpdateLane ();
        }
        foreach (Lane lane1 in lanes) {
            if (lane1.unitsList.Count > 0)
                lane1.UpdateUnitTarget ();
        }
    }
}