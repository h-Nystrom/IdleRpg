using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class BuyUnit : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    public TMP_Text priceText;
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text weaponNameText;
    public TMP_Text weaponDamageText;
    public GameObject unitPrefab;
    public DraggingUnit draggingUnit;
    public LaneChecker[] attackLanes;
    public AttackManagerSO attackManagerSO;
    UnitScriptableObject unitType;
    GameObject newUnit;
    GoldScript gold;
    Transform parent;
    UIIndicator uiIndicator;
    int price;
    int SiblingIndex;
    bool CanBuyUnit {
        get => gold.Amount >= price;
    }
    public void Setup (UnitScriptableObject unitType, LaneChecker[] enemyLanes, DraggingUnit draggingUnit) {
        this.unitType = unitType;
        this.nameText.text = unitType.name;
        this.healthText.text = $"Hp: {unitType.health}";
        this.price = unitType.price;
        this.weaponNameText.text = unitType.startingWeapon.name;
        this.weaponDamageText.text = unitType.startingWeapon.damage.ToString ();
        this.attackLanes = enemyLanes;
        this.draggingUnit = draggingUnit;
        this.priceText.text = $"Price: {this.price}gold";
        //Fix this code to scriptableObject?
        uiIndicator = FindObjectOfType<UIIndicator> ();
        gold = FindObjectOfType<GoldScript> ();
        draggingUnit = FindObjectOfType<DraggingUnit> ();
        //
        parent = draggingUnit.draggableObjectParent;
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
        if (eventData.pointerEnter != null && eventData.pointerEnter.transform.tag == "CombatLane" && !eventData.pointerEnter.GetComponent<LaneChecker> ().IsFull) {
            CalculateSiblingIndex (eventData.position.y, eventData.pointerEnter.transform.position.y);
            newUnit.GetComponent<Unit> ().UpdateUnitLane (eventData.pointerEnter.transform, SiblingIndex);
            attackManagerSO.UpdateAttackTarget ();
            PurchaseUnit ();
        } else {
            Destroy (newUnit);
        }
        newUnit = null;
        draggingUnit.IsDraggingUnit (false);
    }

    public void PurchaseUnit () {
        gold.Amount = -price;
        uiIndicator.SpawnNewIndicator (transform.position, $"-{price}gold", true);
    }
    void ChangeColor () {
        if (CanBuyUnit) {
            priceText.color = Color.yellow;
        } else {
            priceText.color = Color.red;
        }
    }
    void InstatiateUnit () {
        newUnit = Instantiate (unitPrefab, Input.mousePosition, Quaternion.identity, parent);
        newUnit.GetComponent<Unit> ().SetupUnitType (unitType);
        newUnit.GetComponent<Attack> ().SetupWeapon (unitType.startingWeapon);
        newUnit.GetComponent<FindTarget> ().attackLanes = attackLanes;
        newUnit.AddComponent<IgnoreRayCast> ();
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
    void Update () {
        ChangeColor ();
    }
}