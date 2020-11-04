using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUnit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    public DraggingUnit draggingUnit;
    public Lane[] attackLanes;
    Transform parent;
    Transform OldParent;
    int SiblingIndex;
    public void OnBeginDrag (PointerEventData eventData) {
        CalculateSiblingIndex (eventData.pointerEnter.transform.position.y, this.transform.parent.position.y);
        OldParent = this.transform.parent;
        transform.SetParent (parent);
        FindObjectOfType<LaneManager> ().UpdateLanes ();
        GetComponent<FindTarget> ().enemy = null;
        draggingUnit.IsDraggingUnit (true);
    }
    public void OnDrag (PointerEventData eventData) {
        transform.position = eventData.position;
    }
    public void OnEndDrag (PointerEventData eventData) {
        if (eventData.pointerEnter != null && eventData.pointerEnter.transform.tag == "CombatLane") {
            if (eventData.pointerEnter.GetComponent<Lane> ().IsFull) {
                int OldSiblingIndex = SiblingIndex;
                CalculateSiblingIndex (eventData.position.y, eventData.pointerEnter.transform.position.y);
                SwitchUnits (eventData.pointerEnter.GetComponent<Lane> (), OldSiblingIndex);
            } else {
                CalculateSiblingIndex (eventData.position.y, eventData.pointerEnter.transform.position.y);
                GetComponent<Unit> ().UpdateUnitLane (eventData.pointerEnter.transform, SiblingIndex);
            }
        } else {
            ResetUnitPosition ();
        }
        draggingUnit.IsDraggingUnit (false);
    }
    void SwitchUnits (Lane lane, int OldSiblingIndex) {
        Unit unit = lane.unitsList[SiblingIndex];
        unit.UpdateUnitLane (OldParent, OldSiblingIndex);
        GetComponent<Unit> ().UpdateUnitLane (lane.transform, SiblingIndex);
    }
    void CalculateSiblingIndex (float mousePositionY, float lanePositionY) { //Make it a public struct (used in 2 scripts)?
        if (mousePositionY == Mathf.Clamp (mousePositionY, lanePositionY - 20, lanePositionY + 20)) {
            SiblingIndex = 1;
        } else if (mousePositionY > lanePositionY + 20) {
            SiblingIndex = 0;

        } else {
            SiblingIndex = 2;
        }
    }
    void ResetUnitPosition () {
        GetComponent<Unit> ().UpdateUnitLane (OldParent, SiblingIndex);
    }
    void Start () {
        draggingUnit = FindObjectOfType<DraggingUnit> ();
        parent = draggingUnit.draggableObjectParent;
    }

}