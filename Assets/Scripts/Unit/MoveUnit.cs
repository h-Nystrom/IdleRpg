using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUnit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    public DraggingUnit draggingUnit;
    public AttackManagerSO attackManagerSO;
    Transform parent;
    Transform OldParent;
    int SiblingIndex;
    public void OnBeginDrag (PointerEventData eventData) {
        CalculateSiblingIndex (eventData.pointerEnter.transform.position.y, this.transform.parent.position.y);
        OldParent = this.transform.parent;
        OldParent.GetComponent<LaneChecker> ().RemoveUnit (GetComponent<Unit> ());
        transform.SetParent (parent);
        GetComponent<FindTarget> ().enemy = null;
        draggingUnit.IsDraggingUnit (true);
        attackManagerSO.UpdateAttackTarget ();
    }
    public void OnDrag (PointerEventData eventData) {
        transform.position = eventData.position;
    }
    public void OnEndDrag (PointerEventData eventData) {
        if (eventData.pointerEnter != null && eventData.pointerEnter.transform.tag == "CombatLane") {
            if (eventData.pointerEnter.GetComponent<LaneChecker> ().IsFull) {
                int OldSiblingIndex = SiblingIndex;
                CalculateSiblingIndex (eventData.position.y, eventData.pointerEnter.transform.position.y);
                SwitchUnits (eventData.pointerEnter.GetComponent<LaneChecker> (), OldSiblingIndex);
            } else {
                CalculateSiblingIndex (eventData.position.y, eventData.pointerEnter.transform.position.y);
                GetComponent<Unit> ().UpdateUnitLane (eventData.pointerEnter.transform, SiblingIndex);
            }
        } else {
            ResetUnitPosition ();
        }
        draggingUnit.IsDraggingUnit (false);
        attackManagerSO.UpdateAttackTarget ();
    }
    void SwitchUnits (LaneChecker lane, int OldSiblingIndex) {
        Unit unit = lane.unitsInLane[SiblingIndex];
        lane.RemoveUnit (unit);
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