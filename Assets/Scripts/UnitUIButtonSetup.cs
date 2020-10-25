using UnityEngine;

public class UnitUIButtonSetup : MonoBehaviour {
    public GameObject UnitUIPrefab;
    DraggingUnit draggingUnitScript;
    const int maxIndex = 6; //Change to scriptableobject array later!
    void Awake () {
        draggingUnitScript = GetComponent<DraggingUnit> ();
        SetUpButtons ();
    }
    void SetUpButtons () {
        for (int i = 0; i <= maxIndex; i++) {
            GameObject UnitUIButton = Instantiate (UnitUIPrefab, this.transform);
            UnitUIButton.GetComponent<MoveUnit> ().draggingUnit = draggingUnitScript;
        }
    }
}