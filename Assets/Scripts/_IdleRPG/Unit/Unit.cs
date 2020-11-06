using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour {
    [HideInInspector] public Transform parentLane;
    [SerializeField] TMP_Text nameTxt;
    [SerializeField] HealthBar healthBar;
    [SerializeField] AttackManagerSO attackManagerSO;
    bool _isGameRunning = true;
    int maxHealth = 100;
    int health = 100;
    int blockChance = 10;
    UnitType unitType;
    bool isAlive;
    public int BlockChance { get => blockChance; }
    public bool IsAlive {
        get {
            if (health > 0) {
                return true;
            } else {
                return false;
            }
        }
    }
    public void SetupUnitType (UnitScriptableObject unitType) {
        this.name = unitType.name;
        this.nameTxt.text = unitType.name;
        this.maxHealth = unitType.health;
        this.health = maxHealth;
        this.unitType = unitType.unitType;
        this.blockChance = unitType.blockChance;
        healthBar.MaxHealth = maxHealth;
    }
    public void UpdateUnitLane (Transform parentLane, int index) {
        this.parentLane = parentLane;
        transform.SetParent (this.parentLane);
        transform.SetSiblingIndex (index);
        GetComponent<CanvasGroup> ().blocksRaycasts = true;
        parentLane.GetComponent<LaneChecker> ().AddUnit (this, index);
        //if (GetComponent<FindTarget> () != null)
        GetComponent<FindTarget> ()?.Setup (this.parentLane.GetComponent<LaneChecker> ());
    }
    public void TakeDamage (int damage, int crit) {
        if (IsAlive) {
            if (damage > 0) {
                health = Mathf.Clamp (health - damage, 0, maxHealth);
                healthBar.UpdateHealthBar (health);
                if (!IsAlive) {
                    Destroy (this.gameObject);
                }
            }
        }
    }
    void OnDestroy () {
        if (_isGameRunning) {
            //if (parentLane != null) {
            parentLane.GetComponent<LaneChecker> ()?.RemoveUnit (this);
            attackManagerSO.UpdateAttackTarget ();
            //}
        }
    }
    void OnApplicationQuit () {
        _isGameRunning = false;
    }
}