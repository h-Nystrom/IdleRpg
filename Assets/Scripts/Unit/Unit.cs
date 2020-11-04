using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour {
    public Transform parentLane;
    public TMP_Text nameTxt;
    public HealthBar healthBar;
    public UIIndicator uiIndicator;
    FindTarget attackTarget;
    bool _isGameRunning = true;
    int maxHealth = 100;
    int damage = 10;
    int health = 100;
    int CritChance = 1;
    int attackRate = 10;
    int blockChance = 10;
    UnitType unitType;

    float chargingAttack = 0;
    bool isAlive;

    public void SetupUnitType (UnitScriptableObject unitType) {
        this.name = unitType.name;
        this.nameTxt.text = unitType.name;
        this.maxHealth = unitType.health;
        this.health = maxHealth;
        this.unitType = unitType.unitType;
        this.blockChance = unitType.blockChance;
        healthBar.MaxHealth = maxHealth;
    }
    public void SetupWeapon (WeaponScriptableObject weapon) {
        if (weapon.unitType == unitType) {
            this.damage = weapon.damage;
            this.CritChance = weapon.critChance;
            this.attackRate = weapon.attackRate;
        } else {
            Debug.Log ("This unit can't carry this weapon!");
        }
    }

    public void UpdateUnitLane (Transform parentLane, int index) {
        this.parentLane = parentLane;
        transform.SetParent (this.parentLane);
        transform.SetSiblingIndex (index);
        GetComponent<CanvasGroup> ().blocksRaycasts = true;
        FindObjectOfType<LaneManager> ().UpdateLanes ();
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
        if (_isGameRunning) {
            if (parentLane != null) {
                FindObjectOfType<LaneManager> ().UpdateLanes ();
            }
        }
    }
    void OnApplicationQuit () {
        _isGameRunning = false;
    }
    void OnDeath () {
        if (parentLane != null)
            parentLane.GetComponent<Lane> ().unitsList.Remove (this);
        Destroy (this.gameObject);
    }
    void Start () {
        uiIndicator = FindObjectOfType<UIIndicator> ();
        attackTarget = GetComponent<FindTarget> ();
    }
    bool HasTarget => attackTarget.enemy != null;

    void Update () {
        if (HasTarget) {
            ChargingAttack ();
        }
    }
    void ChargingAttack () {
        if (chargingAttack == 0)
            chargingAttack = Time.time;
        if (Time.time - chargingAttack > attackRate) {
            Attack ();
            chargingAttack = Time.time;
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
            uiIndicator.SpawnNewIndicator (enemy.transform.position, $"-{attackDamage}", true);
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