using UnityEngine;

public class DraggingUnit : MonoBehaviour {
    public event SpawnUnitDelegate OnDraggingUnit;
    public delegate void SpawnUnitDelegate (bool InUse);
    public Transform draggableObjectParent;
    public void IsDraggingUnit (bool draggingUnit) {
        //Debug.Log ("Event" + draggingUnit);
        OnDraggingUnit?.Invoke (draggingUnit);
    }
}