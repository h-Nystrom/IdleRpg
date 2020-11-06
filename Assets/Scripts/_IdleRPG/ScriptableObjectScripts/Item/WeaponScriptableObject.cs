using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject {

    public int damage;
    public int critChance;
    public int attackRate;
    public UnitType unitType;
}