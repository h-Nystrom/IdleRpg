using UnityEngine;

public class SpawnCommander : MonoBehaviour {
    public Unit unitPrefab;
    public UnitScriptableObject CommanderUnitSO;
    public SpawnEnemyUnits spawnEnemyUnits;
    void Start () {
        Unit newUnit = Instantiate (unitPrefab, this.transform);
        Destroy (newUnit.GetComponent<Attack> ());
        Destroy (newUnit.GetComponent<MoveUnit> ());
        Destroy (newUnit.GetComponent<FindTarget> ());
        newUnit.gameObject.AddComponent<Commander> ();
        newUnit.gameObject.GetComponent<Commander> ().SetupWeapon (CommanderUnitSO.startingWeapon);
        spawnEnemyUnits.commander = newUnit.GetComponent<Commander> ();
        newUnit.SetupUnitType (CommanderUnitSO);
        newUnit.UpdateUnitLane (transform, 0);
    }
}