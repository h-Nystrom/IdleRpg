using UnityEngine;

public class Unit : MonoBehaviour {

    //Unit Data:
    public string name = "unit name";
    public int health = 100;
    public int blockChance = 10;

    //Weapon Data:
    public int damage = 10;
    public int CritChance = 10;
    public float attackSpeed = 2;
    public bool rangedWeapon = false;
    public bool blockableAttack = false;
    public bool splash;
    public bool poisen;

    //All
    bool chargingAttack;
    float attackDelay;
    FindTarget attackTarget;

    void Start () {
        attackTarget = GetComponent<FindTarget> ();
    }
    bool HasTarget => attackTarget.value != null;

    void Update () {
        if (HasTarget) {
            ChargingAttack ();
        }
    }
    void ChargingAttack () {
        if (attackDelay == 0)
            attackDelay = Time.time;
        if (Time.time - attackDelay > attackSpeed) {
            Attack ();
            attackDelay = Time.time;
        }
    }
    public void Attack () {
        //Calculate:
        //Block, crit, dmg

        Debug.Log ("Attacking!", this.gameObject);
    }
    public void TakeDamage (int damage) {
        //Calculate health:
        //Using: armour

        Debug.Log ("Tacking Damage!", this.gameObject);
    }
}