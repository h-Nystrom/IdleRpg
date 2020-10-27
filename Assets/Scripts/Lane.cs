using UnityEngine;

public class Lane : MonoBehaviour {

    public Unit[] units;
    public int maxUnits = 3;
    bool _isFull;
    public bool IsFull {
        get => _isFull;
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