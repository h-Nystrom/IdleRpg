using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

    public List<Unit> unitsList;
    public int maxUnits = 3;
    Unit[] units;
    bool _isFull;
    public bool IsFull {
        get => _isFull;
    }
    public void UpdateLane () {
        unitsList.Clear ();
        units = GetComponentsInChildren<Unit> ();
        if (units.Length == 0) {
            return;
        }
        foreach (Unit unit in units) {
            if (unit.IsAlive) {
                unit.GetComponent<FindTarget> ().enemy = null;
                unitsList.Add (unit);
            }
        }
        IsLaneFull ();
    }
    public void UpdateUnitTarget () {
        for (int i = 0; i < unitsList.Count; i++) {
            unitsList[i].GetComponent<FindTarget> ().UpdateTarget (i, unitsList.Count);
        }
    }
    void IsLaneFull () {
        if (unitsList.Count >= maxUnits)
            _isFull = true;
        else
            _isFull = false;
    }

}