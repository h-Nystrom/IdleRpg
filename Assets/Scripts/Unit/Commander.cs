using UnityEngine;

[RequireComponent (typeof (Unit))]
public class Commander : MonoBehaviour {
    public int damage = 5;
    UIIndicator uIIndicator;
    public void SetupWeapon (WeaponScriptableObject weapon) {
        this.damage = weapon.damage;
    }
    public void OnEnemyClick (Unit unitTarget) {
        uIIndicator.SpawnNewIndicator (Input.mousePosition + new Vector3 (Random.Range (-10, 10), Random.Range (-10, 10), 0), $"-{damage}", true);
        unitTarget.TakeDamage (damage, 0);
    }
    void Start () {
        uIIndicator = FindObjectOfType<UIIndicator> ();
    }
    void OnDestroy () {
        //TODO Call Game over event!
        Time.timeScale = 0;
    }
}