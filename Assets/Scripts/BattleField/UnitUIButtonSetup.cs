using UnityEngine;

public class UnitUIButtonSetup : MonoBehaviour {
    public MoveUnit UnitUIPrefab;

    DraggingUnit draggingUnitScript;
    LaneManager laneManager;
    const int maxIndex = 6; //Change to scriptableobject array later!
    void Awake () {
        laneManager = FindObjectOfType<LaneManager> ();
        draggingUnitScript = GetComponent<DraggingUnit> ();
        SetUpButtons ();
    }
    void SetUpButtons () {
        for (int i = 0; i <= maxIndex; i++) {
            MoveUnit UnitUIButton = Instantiate (UnitUIPrefab, this.transform);
            UnitUIButton.draggingUnit = draggingUnitScript;
            UnitUIButton.attackLanes = laneManager.enemyLanes;
        }
    }
}