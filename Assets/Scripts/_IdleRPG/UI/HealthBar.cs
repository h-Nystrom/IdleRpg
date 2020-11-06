using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image fillUI;
    int maxValue;
    public Slider healthBar;
    public int MaxHealth {
        get => maxValue;
        set => maxValue = value;
    }
    public void UpdateHealthBar (int health) {
        healthBar.value = health;
        if (health < 20) {
            fillUI.color = Color.red;
        } else if (health == Mathf.Clamp (health, 20, healthBar.maxValue / 2)) {
            fillUI.color = Color.yellow;
        } else {
            fillUI.color = Color.green;
        }
    }
}