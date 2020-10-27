using TMPro;
using UnityEngine;

[RequireComponent (typeof (FindTarget))]
public class Unit : MonoBehaviour {

    //Unit Data:
    public string unitName = "unit name";
    public int health = 100;
    public int blockChance = 10;
    public UnitType unitType;
    public enum UnitType {
        Melee,
        Range,
        Hero
    }

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
    Transform parentLane;
    public TMP_Text nameTxt;
    public void SetupUnit (Transform parentLane, int index) {
        this.parentLane = parentLane;
        transform.SetParent (this.parentLane);
        transform.SetSiblingIndex (index);

        transform.position = this.parentLane.position;
        GetComponent<CanvasGroup> ().blocksRaycasts = true;
        parentLane.GetComponent<Lane> ().UpdateArray ();
    }
    void Start () {
        nameTxt.text = $"Warrior {Random.Range(0, 101)}"; //Change to name
        attackTarget = GetComponent<FindTarget> ();
    }
    bool HasTarget => attackTarget.enemy != null;

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

        Debug.Log ($"Attacking {attackTarget.enemy.GetComponent<Unit>().nameTxt.text}!");
    }
    public void TakeDamage (int damage) {
        //Calculate health:
        //Using: armour

        Debug.Log ("Tacking Damage!", this.gameObject);
    }
}