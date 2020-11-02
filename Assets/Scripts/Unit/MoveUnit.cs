using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUnit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    //Seperate this script to buyNewUnit and moveUnit.
    public GameObject unitPrefab;
    public Transform parent;
    public Transform IgnoreRaycastParent;
    public DraggingUnit draggingUnit;
    public Lane[] attackLanes;
    GoldScript goldScript;
    GameObject newUnit;
    bool canSpawnNewUnit;
    Transform OldParent;
    int SiblingIndex;
    public void OnBeginDrag (PointerEventData eventData) {

        if (unitPrefab != null) {
            if (goldScript.Amount >= 100) {
                newUnit = Instantiate (unitPrefab, parent);
                newUnit.AddComponent<IgnoreRayCast> ();
                newUnit.GetComponent<FindTarget> ().attackLanes = this.attackLanes;
                newUnit.GetComponent<UIIndicator> ().ignoreRaycastParent = IgnoreRaycastParent;
                newUnit.GetComponent<FindTarget> ().enemy = null;
                draggingUnit.IsDraggingUnit (true);
            }
        } else {
            CalculateSiblingIndex (eventData.pointerEnter.transform.position.y, this.transform.parent.position.y);
            newUnit = this.gameObject;
            OldParent = this.transform.parent;
            transform.SetParent (parent);
            FindObjectOfType<LaneManager> ().UpdateLanes ();
            newUnit.GetComponent<FindTarget> ().enemy = null;
            draggingUnit.IsDraggingUnit (true);
        }
    }
    public void OnDrag (PointerEventData eventData) {
        if (newUnit != null)
            newUnit.transform.position = eventData.position;
    }
    public void OnEndDrag (PointerEventData eventData) {
        if (newUnit != null) {
            if (eventData.pointerEnter != null && eventData.pointerEnter.transform.tag == "CombatLane") {
                if (eventData.pointerEnter.GetComponent<Lane> ().IsFull) {
                    int OldSiblingIndex = SiblingIndex;
                    CalculateSiblingIndex (eventData.position.y, eventData.pointerEnter.transform.position.y);
                    SwitchUnits (eventData.pointerEnter.GetComponent<Lane> (), OldSiblingIndex);
                } else {
                    CalculateSiblingIndex (eventData.position.y, eventData.pointerEnter.transform.position.y);
                    newUnit.GetComponent<Unit> ().SetupUnit (eventData.pointerEnter.transform, SiblingIndex);
                    if (unitPrefab != null) {
                        goldScript.Amount = -100;
                        GetComponent<UIIndicator> ().SpawnNewIndicator (transform.position, $"-100gold", true);
                    }
                }
            } else {
                ResetUnitPosition ();
            }
            draggingUnit.IsDraggingUnit (false);
            newUnit = null;
        }
    }
    void SwitchUnits (Lane lane, int OldSiblingIndex) {
        if (unitPrefab != null) {
            Destroy (newUnit);
        } else {
            Unit unit = lane.unitsList[SiblingIndex];
            unit.SetupUnit (OldParent, OldSiblingIndex);
            newUnit.GetComponent<Unit> ().SetupUnit (lane.transform, SiblingIndex);
        }
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
    void Start () {
        goldScript = FindObjectOfType<GoldScript> ();
        draggingUnit = FindObjectOfType<DraggingUnit> ();
        parent = draggingUnit.draggableObjectParent;
        IgnoreRaycastParent = GameObject.FindWithTag ("FloatText").transform;
    }

}