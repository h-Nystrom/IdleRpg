using TMPro;
using UnityEngine;

public class GoldScript : MonoBehaviour {
    public TMP_Text goldText;
    int _goldAmount;
    void Start () {
        _goldAmount = PlayerPrefs.GetInt ("savedGold", 0);
        goldText.text = $"Gold: {Amount}";
    }
    void OnDestroy () {
        PlayerPrefs.SetInt ("savedGold", _goldAmount);
    }
    public int Amount {
        get => _goldAmount;
        set {
            _goldAmount += value;
            goldText.text = $"Gold: {Amount}";
        }
    }
}