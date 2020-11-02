using UnityEngine;

public class IgnoreRayCast : MonoBehaviour {

    public DraggingUnit DraggingUnit;
    void Start () {
        DraggingUnit = FindObjectOfType<DraggingUnit> ();
        DraggingUnit.OnDraggingUnit += OnDraggingUnit;
    }
    void OnDestroy () {
        DraggingUnit.OnDraggingUnit -= OnDraggingUnit;
    }
    void OnDraggingUnit (bool InUse) {
        if (InUse) {
            GetComponent<CanvasGroup> ().alpha = 0.9f;
            GetComponent<CanvasGroup> ().blocksRaycasts = false;
        } else {
            GetComponent<CanvasGroup> ().alpha = 1f;
            GetComponent<CanvasGroup> ().blocksRaycasts = true;
        }
    }
}