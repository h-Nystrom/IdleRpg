using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUnit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    public GameObject unitPrefab;
    public Transform parent;
    public Transform IgnoreRaycastParent;
    public DraggingUnit draggingUnit;
    GameObject newUnit;
    bool canSpawnNewUnit;
    Transform OldParent;
    int SiblingIndex;
    void Start () {
        draggingUnit = FindObjectOfType<DraggingUnit> ();
        parent = draggingUnit.draggableObjectParent;
        IgnoreRaycastParent = GameObject.FindWithTag ("FloatText").transform;
    }
    public void OnBeginDrag (PointerEventData eventData) {

        if (unitPrefab != null) {
            //Check if you have enough cash here!
            newUnit = Instantiate (unitPrefab, parent);
            newUnit.AddComponent<IgnoreRayCast> ();
            newUnit.GetComponent<UIIndicator> ().ignoreRaycastParent = IgnoreRaycastParent;
        } else {
            CalculateSiblingIndex (eventData.pointerEnter.transform.position.y, this.transform.parent.position.y);
            newUnit = this.gameObject;
            OldParent = this.transform.parent;
            transform.SetParent (parent);
            OldParent.GetComponent<Lane> ().UpdateArray ();
            OldParent.GetComponent<Lane> ().UpdateOpponentsLanes ();
        }
        newUnit.GetComponent<FindTarget> ().enemy = null;
        draggingUnit.IsDraggingUnit (true);
    }
    public void OnDrag (PointerEventData eventData) {
        newUnit.transform.position = eventData.position;
    }
    public void OnEndDrag (PointerEventData eventData) {
        if (eventData.pointerEnter != null) {
            if (eventData.pointerEnter.transform.tag != "CombatLane" || eventData.pointerEnter.GetComponent<Lane> ().IsFull) {
                ResetUnitPosition ();
            } else {
                CalculateSiblingIndex (eventData.position.y, eventData.pointerEnter.transform.position.y);
                newUnit.GetComponent<Unit> ().SetupUnit (eventData.pointerEnter.transform, SiblingIndex);
            }
        } else {
            ResetUnitPosition ();

        }
        draggingUnit.IsDraggingUnit (false);
    }
    void CalculateSiblingIndex (float mousePositionY, float lanePositionY) {
        if (mousePositionY == Mathf.Clamp (mousePositionY, lanePositionY - 20, lanePositionY + 20)) {
            SiblingIndex = 1;
        } else if (mousePositionY > lanePositionY + 20) {
            SiblingIndex = 0;

        } else {
            SiblingIndex = 2;
        }
    }
    void ResetUnitPosition () {
        if (unitPrefab != null)
            Destroy (newUnit);
        else {
            newUnit.GetComponent<Unit> ().SetupUnit (OldParent, SiblingIndex);
        }
    }

}