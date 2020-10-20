using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour {
    public int goldEarnedByClick = 5;
    public TMP_Text goldText;
    int gold;

    void Start () {
        gold = PlayerPrefs.GetInt ("savedGold", 0);
        goldText.text = gold.ToString ("Gold: 0");
    }
    void OnDestroy () {
        PlayerPrefs.SetInt ("savedGold", gold);
    }
    public int CurrentGold { get => gold; }
    public void PlayerProducedGold () {
        gold += goldEarnedByClick;
        goldText.text = gold.ToString ("Gold: 0");
    }
    public void ItemProducedGold (int amount) {
        gold += amount;
        goldText.text = gold.ToString ("Gold: 0");
    }
    public void SpendGold (int cost) {
        gold -= cost;
        goldText.text = gold.ToString ("Gold: 0");
    }
}