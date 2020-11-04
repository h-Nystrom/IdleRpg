using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Lane))]
public class SpawnCommander : MonoBehaviour {
    public Unit unitPrefab;
    public UnitScriptableObject CommanderUnitSO;
    void Start () {
        Unit newUnit = Instantiate (unitPrefab, this.transform);
        newUnit.gameObject.AddComponent<Commander> ();
        newUnit.gameObject.GetComponent<Commander> ().SetupWeapon (CommanderUnitSO.startingWeapon);
        FindObjectOfType<SpawnUnit> ().commander = newUnit.GetComponent<Commander> ();
        newUnit.SetupUnitType (CommanderUnitSO);
        newUnit.UpdateUnitLane (transform, 0);
    }
}