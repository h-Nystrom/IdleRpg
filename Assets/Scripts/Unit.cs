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
        Commander
    }

    //Weapon Data:
    public int damage = 10;
    [Range (0, 3)]
    public int weaponRange = 3;
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
    public Transform parentLane;
    public TMP_Text nameTxt;
    public HealthBar healthBar;
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
    void OnDestroy () {
        if (parentLane != null) {
            parentLane.GetComponent<Lane> ().UpdateArray ();
            parentLane.GetComponent<Lane> ().UpdateOpponentsLanes ();
        }
    }
    void OnDeath () {
        parentLane.GetComponent<Lane> ().unitsList.Remove (this);
        //parentLane.GetComponent<Lane> ().Invoke ("UpdateArray", 0.1f);
        //parentLane.GetComponent<Lane> ().Invoke ("UpdateOpponentsLanes", 0.1f);
        Destroy (this.gameObject);
    }
    public void SetupUnit (Transform parentLane, int index) {
        this.parentLane = parentLane;
        transform.SetParent (this.parentLane);
        transform.SetSiblingIndex (index);
        GetComponent<CanvasGroup> ().blocksRaycasts = true;
        parentLane.GetComponent<Lane> ().UpdateArray ();
        parentLane.GetComponent<Lane> ().UpdateOpponentsLanes ();
        healthBar.MaxHealth = maxHealth;
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
            GetComponent<UIIndicator> ().SpawnNewIndicator (enemy.transform.position, $"-{attackDamage}", true);
        }

    }
    public void TakeDamage (int damage, int crit) {
        if (IsAlive) {
            if (damage > 0) {
                health = Mathf.Clamp (health - damage, 0, maxHealth);
                healthBar.UpdateHealthBar (health);
                if (!IsAlive) {
                    OnDeath ();
                }
            }
        }
    }
}