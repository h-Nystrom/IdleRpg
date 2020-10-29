using UnityEngine;

public class LaneManager : MonoBehaviour {
    public Lane[] lanes;

    public void UpdateLanes () {
        foreach (Lane lane in lanes) {
            lane.UpdateLane ();
        }
    }
}