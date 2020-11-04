using UnityEngine;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour {
    public Unit unitPrefab;
    public EnemyCommanderArmyScriptableObject[] enemyCommanderArmySOs;
    public Transform[] enemyLanes;
    LaneManager laneManager;
    [HideInInspector]
    public Commander commander;
    int level;
    void Start () {
        laneManager = FindObjectOfType<LaneManager> ();
        SpawnEnemyCommander ();
    }
    void SpawnLoop (Transform spawnLane, UnitScriptableObject[] enemyUnits) {
        foreach (UnitScriptableObject unitSO in enemyUnits) {
            if (unitSO == null)
                return;
            Unit newUnit = Instantiate (unitPrefab, this.transform);
            Button button = newUnit.gameObject.AddComponent<Button> ();
            button.transition = Selectable.Transition.None;
            button.onClick.AddListener (() => { commander.OnEnemyClick (newUnit); });
            newUnit.GetComponent<FindTarget> ().attackLanes = laneManager.playerLanes;
            Destroy (newUnit.GetComponent<MoveUnit> ());
            newUnit.gameObject.AddComponent<SpawnLoot> ();
            newUnit.SetupUnitType (unitSO);
            newUnit.SetupWeapon (unitSO.startingWeapon);
            newUnit.UpdateUnitLane (spawnLane.transform, 0);
        }
    }
    public void SpawningEnemyUnits (UnitScriptableObject[] enemyUnitsInFirstLane, UnitScriptableObject[] enemyUnitsInSecondLane) {
        SpawnLoop (enemyLanes[0], enemyUnitsInFirstLane);
        SpawnLoop (enemyLanes[1], enemyUnitsInSecondLane);
    }
    public void SpawnEnemyCommander () {
        Unit newUnit = Instantiate (unitPrefab, this.transform);
        Destroy (newUnit.GetComponent<MoveUnit> ());
        newUnit.GetComponent<Unit> ().SetupUnitType (enemyCommanderArmySOs[level].enemyCommander);
        newUnit.gameObject.AddComponent<EnemyCommander> ();
        newUnit.GetComponent<FindTarget> ().canAttack = false;
        newUnit.UpdateUnitLane (transform, 0);
        SpawningEnemyUnits (enemyCommanderArmySOs[level].unitsInFirstLane, enemyCommanderArmySOs[level].unitsInSecondLane);
        if (level < enemyCommanderArmySOs.Length - 1)
            level++;
    }
}