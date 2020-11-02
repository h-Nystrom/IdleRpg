using UnityEngine;

public class UnitUIButtonSetup : MonoBehaviour {
    public BuyUnit UnitUIPrefab;

    DraggingUnit draggingUnitScript;
    LaneManager laneManager;
    const int maxIndex = 6; //Change to scriptableobject array here!
    void Awake () {
        laneManager = FindObjectOfType<LaneManager> ();
        draggingUnitScript = GetComponent<DraggingUnit> ();
        SetUpButtons ();
    }
    void SetUpButtons () { //Add scriptable objects here!
        for (int i = 0; i <= maxIndex; i++) {
            BuyUnit UnitUIButton = Instantiate (UnitUIPrefab, this.transform);
            UnitUIButton.draggingUnit = draggingUnitScript;
            UnitUIButton.attackLanes = laneManager.enemyLanes;
        }
    }
}