using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemyUnits : MonoBehaviour {
    public Unit unitPrefab;
    public AttackManagerSO attackManagerSO;
    public EnemyCommanderArmyScriptableObject[] enemyCommanderArmySOs;
    public Transform[] enemyLanes;
    [SerializeField] LaneManager laneManager;
    [HideInInspector] public Commander commander;
    int level;
    public void SpawnEnemyCommander () {
        Unit newUnit = Instantiate (unitPrefab, this.transform);
        SetupUnit (newUnit, enemyCommanderArmySOs[level].enemyCommander, this.transform);
        newUnit.gameObject.AddComponent<EnemyCommander> ();
        newUnit.GetComponent<EnemyCommander> ().spawnEnemyUnits = this;
        SpawningUnits (enemyCommanderArmySOs[level].unitsInFirstLane, enemyCommanderArmySOs[level].unitsInSecondLane);
        if (level < enemyCommanderArmySOs.Length - 1)
            level++;
        attackManagerSO.UpdateAttackTarget ();
    }
    public void SpawningUnits (UnitScriptableObject[] enemyUnitsInFirstLane, UnitScriptableObject[] enemyUnitsInSecondLane) {
        SpawnInLane (enemyLanes[0], enemyUnitsInFirstLane);
        SpawnInLane (enemyLanes[1], enemyUnitsInSecondLane);
    }
    void Start () {
        this.Invoke ("SpawnEnemyCommander", 2);
    }
    void SetupUnit (Unit newUnit, UnitScriptableObject unitSO, Transform parentLane) {
        Destroy (newUnit.GetComponent<MoveUnit> ());
        newUnit.GetComponent<FindTarget> ().attackLanes = laneManager.PlayerLanes ();
        newUnit.gameObject.AddComponent<SpawnLoot> ();
        newUnit.GetComponent<Attack> ().SetupWeapon (unitSO.startingWeapon);
        newUnit.SetupUnitType (unitSO);
        newUnit.UpdateUnitLane (parentLane, 0);
    }
    void SpawnInLane (Transform spawnLane, UnitScriptableObject[] enemyUnits) {
        foreach (UnitScriptableObject unitSO in enemyUnits) {
            if (unitSO == null)
                return;
            Unit newUnit = Instantiate (unitPrefab, this.transform);
            SetupUnit (newUnit, unitSO, spawnLane);
            Button button = newUnit.gameObject.AddComponent<Button> ();
            button.transition = Selectable.Transition.None;
            button.onClick.AddListener (() => { commander.OnEnemyClick (newUnit); });
        }
    }
}