using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Lane : MonoBehaviour {
    public bool _isFull;
    public Unit[] units;
    public int maxUnits = 5;
    public bool IsFull {
        get => _isFull;
    }

    public void UpdateArray () {
        units = GetComponentsInChildren<Unit> ();
        if (units.Length >= maxUnits)
            _isFull = true;
        else
            _isFull = false;
    }
}