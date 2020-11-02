using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class BuyUnit : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    public TMP_Text priceText;
    public GameObject unitPrefab;
    public DraggingUnit draggingUnit;
    public Lane[] attackLanes;
    public Transform IgnoreRaycastParent;
    //Add unit scriptableObject here!
    GameObject newUnit;
    GoldScript gold;
    Transform parent;
    int _unitPrice = 100;
    int SiblingIndex;
    bool CanBuyUnit {
        get => gold.Amount >= _unitPrice;
    }

    public void OnBeginDrag (PointerEventData eventData) {
        if (CanBuyUnit) {
            InstatiateUnit ();
        }
    }
    public void OnDrag (PointerEventData eventData) {
        if (newUnit != null)
            newUnit.transform.position = eventData.position;
    }

    public void OnEndDrag (PointerEventData eventData) {
        if (newUnit == null)
            return;

        if (eventData.pointerEnter != null && eventData.pointerEnter.transform.tag == "CombatLane" && !eventData.pointerEnter.GetComponent<Lane> ().IsFull) {
            CalculateSiblingIndex (eventData.position.y, eventData.pointerEnter.transform.position.y);
            newUnit.GetComponent<Unit> ().SetupUnit (eventData.pointerEnter.transform, SiblingIndex);
            PurchaseUnit ();
        } else {
            Destroy (newUnit);
        }
        newUnit = null;
        draggingUnit.IsDraggingUnit (false);
    }

    public void PurchaseUnit () {
        gold.Amount = -_unitPrice;
        GetComponent<UIIndicator> ().SpawnNewIndicator (transform.position, $"-{_unitPrice}gold", true);
    }
    void InstatiateUnit () {
        newUnit = Instantiate (unitPrefab, Input.mousePosition, Quaternion.identity, parent);
        newUnit.AddComponent<IgnoreRayCast> ();
        newUnit.GetComponent<FindTarget> ().attackLanes = this.attackLanes;
        newUnit.GetComponent<UIIndicator> ().ignoreRaycastParent = this.IgnoreRaycastParent;
        newUnit.GetComponent<FindTarget> ().enemy = null;
        draggingUnit.IsDraggingUnit (true);
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
    void Start () {
        gold = FindObjectOfType<GoldScript> ();
        draggingUnit = FindObjectOfType<DraggingUnit> ();
        parent = draggingUnit.draggableObjectParent;
        IgnoreRaycastParent = GameObject.FindWithTag ("FloatText").transform;
        GetComponent<UIIndicator> ().ignoreRaycastParent = IgnoreRaycastParent;
        priceText.text = $"Price: {_unitPrice}gold";
    }
}