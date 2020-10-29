using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

    public List<Unit> unitsList;
    Unit[] units;
    public int maxUnits = 3;
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
        UpdateUnitTarget ();
        IsLaneFull ();
    }
    void IsLaneFull () {
        if (unitsList.Count >= maxUnits)
            _isFull = true;
        else
            _isFull = false;
    }
    public void UpdateUnitTarget () {
        for (int i = 0; i < unitsList.Count; i++) {
            unitsList[i].GetComponent<FindTarget> ().UpdateTarget (i, unitsList.Count);
        }
    }
}