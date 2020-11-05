using UnityEngine;

public class UnitUIButtonSetup : MonoBehaviour {
    public BuyUnit UnitUIPrefab;
    DraggingUnit draggingUnitScript;
    [SerializeField] LaneManager laneManager;
    [SerializeField] UnitScriptableObject[] unitTypes = new UnitScriptableObject[maxIndex];
    const int maxIndex = 6;
    void Awake () {
        draggingUnitScript = GetComponent<DraggingUnit> ();
        SetUp ();
    }
    void SetUp () {
        for (int i = 0; i < unitTypes.Length; i++) {
            BuyUnit UnitUIButton = Instantiate (UnitUIPrefab, this.transform);
            UnitUIButton.Setup (unitTypes[i], laneManager.EnemyLanes (), draggingUnitScript);
        }
    }
}