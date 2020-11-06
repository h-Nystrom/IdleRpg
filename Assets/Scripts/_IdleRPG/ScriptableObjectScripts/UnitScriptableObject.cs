using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObject/Units")]
public class UnitScriptableObject : ScriptableObject {
    public int health;
    public int blockChance;
    public int price;
    public UnitType unitType;
    //Unit sprite here!
    public WeaponScriptableObject startingWeapon;
}
public enum UnitType {
    Light,
    Medium,
    Heavy
}