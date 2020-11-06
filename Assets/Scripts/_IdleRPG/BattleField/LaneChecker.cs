using System.Collections.Generic;
using UnityEngine;
public class LaneChecker : MonoBehaviour {
    public List<Unit> unitsInLane = new List<Unit> (3);
    [SerializeField] int maxUnits = 3;
    public bool IsFull {
        get {
            if (unitsInLane.Count >= maxUnits)
                return true;
            else
                return false;
        }
    }
    public void AddUnit (Unit unit, int index) {
        if (index < unitsInLane.Count)
            unitsInLane.Insert (index, unit);
        else
            unitsInLane.Add (unit);
    }
    public void RemoveUnit (Unit unit) {
        unitsInLane.Remove (unit);
    }
}