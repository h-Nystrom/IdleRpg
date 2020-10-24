using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingUnit : MonoBehaviour {
    public event SpawnUnitDelegate OnDraggingUnit;
    public delegate void SpawnUnitDelegate (bool InUse);

    public void IsDraggingUnit (bool draggingUnit) {
        Debug.Log ("Event" + draggingUnit);
        OnDraggingUnit?.Invoke (draggingUnit);
    }
}