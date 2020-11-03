using UnityEngine;

public class UnitUIButtonSetup : MonoBehaviour {
    public BuyUnit UnitUIPrefab;

    DraggingUnit draggingUnitScript;
    LaneManager laneManager;
    public UnitScriptableObject[] unitTypes = new UnitScriptableObject[maxIndex];
    const int maxIndex = 6;
    void Awake () {
        laneManager = FindObjectOfType<LaneManager> ();
        draggingUnitScript = GetComponent<DraggingUnit> ();
        SetUpButtons ();
    }
    void SetUpButtons () {
        for (int i = 0; i < unitTypes.Length; i++) {
            BuyUnit UnitUIButton = Instantiate (UnitUIPrefab, this.transform);
            UnitUIButton.Setup (unitTypes[i], laneManager.enemyLanes, draggingUnitScript);
        }
    }
}