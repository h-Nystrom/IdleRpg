using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObject/EnemyArmy")]
public class EnemyCommanderArmyScriptableObject : ScriptableObject {
    public UnitScriptableObject enemyCommander;
    public UnitScriptableObject[] unitsInFirstLane = new UnitScriptableObject[3];
    public UnitScriptableObject[] unitsInSecondLane = new UnitScriptableObject[3];
}