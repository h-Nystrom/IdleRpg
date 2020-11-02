using UnityEngine;

[RequireComponent (typeof (Unit), typeof (UIIndicator))]
public class Commander : MonoBehaviour {
    //Click on opponent to deal dmg. 
    //Gain combos by clicking on enemy units ex. > 10clicks/s.
    //Click on own units to select them.
    //Click on Items to collect them into your inventory.
    public int damage = 5;
    UIIndicator uIIndicator;
    public void OnEnemyClick (Unit unitTarget) {
        uIIndicator.SpawnNewIndicator (Input.mousePosition, $"-{damage}", true);
        unitTarget.TakeDamage (damage, 0);
    }
    void Start () {
        uIIndicator = GetComponent<UIIndicator> ();
    }
    void OnDestroy () {
        Time.timeScale = 0;
    }
}