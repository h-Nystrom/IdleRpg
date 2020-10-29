using UnityEngine;

public class UnitUIButtonSetup : MonoBehaviour {
    public GameObject UnitUIPrefab;

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
            GameObject UnitUIButton = Instantiate (UnitUIPrefab, this.transform);
            UnitUIButton.GetComponent<MoveUnit> ().draggingUnit = draggingUnitScript;
            UnitUIButton.GetComponent<MoveUnit> ().attackLanes = laneManager.enemyLanes;
        }
    }
}