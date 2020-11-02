using TMPro;
using UnityEngine;

public class GoldScript : MonoBehaviour {
    public TMP_Text goldText;
    int _goldAmount;
    void Start () {
        _goldAmount = PlayerPrefs.GetInt ("savedGold", 0);
        goldText.text = $"Gold: {GoldAmount}";
    }
    void OnDestroy () {
        PlayerPrefs.SetInt ("savedGold", _goldAmount);
    }
    public int GoldAmount {
        get => _goldAmount;
        set {
            _goldAmount += value;
            goldText.text = $"Gold: {GoldAmount}";
        }
    }
}