using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour {
    public int goldEarnedByClick = 5;
    public TMP_Text goldText;
    int _goldAmount;

    void Start () {
        _goldAmount = PlayerPrefs.GetInt ("savedGold", 0);
        goldText.text = _goldAmount.ToString ("Gold: 0");
    }
    void OnDestroy () {
        PlayerPrefs.SetInt ("savedGold", _goldAmount);
    }
    public int GoldAmount {
        get => _goldAmount;
        set {
            _goldAmount = value;
            goldText.text = _goldAmount.ToString ("Gold: 0");
        }
    }
    public void PlayerProducedGold () {
        GoldAmount += goldEarnedByClick;
        goldText.text = GoldAmount.ToString ("Gold: 0");
    }
    public void ItemProducedGold (int amount) {
        GoldAmount += amount;
        goldText.text = GoldAmount.ToString ("Gold: 0");
    }
    public void SpendGold (int cost) {
        GoldAmount -= cost;
    }
}