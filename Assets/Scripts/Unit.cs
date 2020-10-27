using TMPro;
using UnityEngine;

[RequireComponent (typeof (FindTarget))]
public class Unit : MonoBehaviour {

    //Unit Data:
    public string unitName = "unit name";
    public int maxHealth = 100;
    public int blockChance = 10;
    public UnitType unitType;
    public enum UnitType {
        Melee,
        Range,
        Support,
        Scavanger,
        Hero
    }

    //Weapon Data:
    public int damage = 10;
    [Range (0, 2)]
    public int weaponRange = 1;
    public int CritChance = 10;
    public float attackSpeed = 2;
    public bool blockableAttack = false;
    public bool splash;
    public bool poisen;
    float attackRate; //Weapon attackRate
    //All
    int health = 100;
    bool isAlive;
    bool chargingAttack;
    FindTarget attackTarget;
    Transform parentLane;
    public TMP_Text nameTxt;
    public int AttackRange {
        get => weaponRange;
    }
    public bool IsAlive {
        get {
            if (health > 0) {
                return true;
            } else {
                return false;
            }
        }
    }
    void OnDeath () {
        Destroy (this.gameObject);
        if (parentLane != null) {
            parentLane.GetComponent<Lane> ().UpdateArray ();
            parentLane.GetComponent<Lane> ().UpdateOpponentsLanes ();
        }
    }
    public void SetupUnit (Transform parentLane, int index) {
        this.parentLane = parentLane;
        transform.SetParent (this.parentLane);
        transform.SetSiblingIndex (index);
        GetComponent<CanvasGroup> ().blocksRaycasts = true;
        parentLane.GetComponent<Lane> ().UpdateArray ();
        parentLane.GetComponent<Lane> ().UpdateOpponentsLanes ();
    }
    void Start () {
        health = maxHealth;
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
        if (attackRate == 0)
            attackRate = Time.time;
        if (Time.time - attackRate > attackSpeed) {
            Attack ();
            attackRate = Time.time;
        }
    }
    public void Attack () {
        //Calculate:
        if (attackTarget.enemy != null) {
            Unit enemy = attackTarget.enemy.GetComponent<Unit> ();
            int enemyBlockChance = Random.Range (0, 101);
            int attackDamage = 0;
            int CritDamage = 0;
            if (enemyBlockChance > enemy.blockChance) {
                CritDamage = Random.Range (0, 101);
                if (CritDamage <= CritChance)
                    attackDamage = damage + CritDamage;
                else {
                    attackDamage = damage;
                    CritDamage = 0;
                }
            }
            enemy.TakeDamage (attackDamage, CritDamage);
        }
    }
    public void TakeDamage (int damage, int crit) {
        //Decrease dmg dependent on armour
        //Check if the unit have powers shield activated
        if (damage > 0) {
            health = Mathf.Clamp (health - damage, 0, maxHealth);
            if (!IsAlive) {
                Debug.Log ("Dead!");
                OnDeath ();
            }
        } else {
            Debug.Log (nameTxt.text + " dodged the attack!");
        }

    }
}