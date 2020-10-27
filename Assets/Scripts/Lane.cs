using UnityEngine;

public class Lane : MonoBehaviour {

    public Unit[] units;
    public Lane[] OpponentsLanes = new Lane[3];
    public int maxUnits = 3;
    bool _isFull;
    public bool IsFull {
        get => _isFull;
    }
    public void UpdateOpponentsLanes () {
        if (OpponentsLanes.Length == 0) {
            Debug.Log ("Missing Opponents lanes");
            return;
        }
        foreach (Lane lane in OpponentsLanes) {
            lane.UpdateArray ();
        }
    }
    public void UpdateArray () {
        units = GetComponentsInChildren<Unit> ();
        if (units.Length >= maxUnits)
            _isFull = true;
        else
            _isFull = false;
        UpdateUnitTarget ();
    }
    void UpdateUnitTarget () {
        for (int i = 0; i < units.Length; i++) {
            units[i].GetComponent<FindTarget> ().UpdateTarget (i, units.Length);
        }
    }
}