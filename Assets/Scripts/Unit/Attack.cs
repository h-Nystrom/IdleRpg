using UnityEngine;

[RequireComponent (typeof (Unit), typeof (FindTarget))]
public class Attack : MonoBehaviour {
    public GameObject enemy => GetComponent<FindTarget> ().enemy;
    UIIndicator uiIndicator;
    int damage = 10;
    int critChance = 1;
    int attackRate = 10;
    float chargingAttack = 0;
    public bool HasTarget { get => enemy != null; }
    public void SetupWeapon (WeaponScriptableObject weaponSO) {
        this.damage = weaponSO.damage;
        this.critChance = weaponSO.critChance;
        this.attackRate = weaponSO.attackRate;
    }
    public void Attacking () {
        if (enemy == null)
            return;
        int enemyBlockChance = Random.Range (0, 101);
        int attackDamage = 0;
        int critDamage = 0;
        if (enemyBlockChance > enemy.GetComponent<Unit> ().BlockChance) {
            critDamage = Random.Range (0, 101);
            if (critDamage <= critChance)
                attackDamage = damage + critDamage;
            else {
                attackDamage = damage;
                critDamage = 0;
            }
        }
        enemy.GetComponent<Unit> ().TakeDamage (attackDamage, critDamage);
        uiIndicator.SpawnNewIndicator (enemy.transform.position + new Vector3 (Random.Range (-30, 30), Random.Range (-20, 5), 0), $"-{attackDamage}", true);
    }
    void ChargingAttack () {
        if (chargingAttack == 0)
            chargingAttack = Time.time;
        if (Time.time - chargingAttack > attackRate) {
            Attacking ();
            chargingAttack = Time.time;
        }
    }
    void Update () {
        if (HasTarget) {
            ChargingAttack ();
        }
    }
    void Start () {
        uiIndicator = FindObjectOfType<UIIndicator> ();
    }
}