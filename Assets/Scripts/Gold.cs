using TMPro;
using UnityEngine;

[RequireComponent (typeof (GoldUI))]
public class Gold : MonoBehaviour {
    public int goldEarnedByClick = 5;
    public TMP_Text goldText;
    int _goldAmount;
    GoldUI goldUI;
    void Start () {
        _goldAmount = PlayerPrefs.GetInt ("savedGold", 0);
        goldText.text = _goldAmount.ToString ("Gold: 0");
        goldUI = GetComponent<GoldUI> ();
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
        goldUI.SpawnGoldText (Input.mousePosition, goldEarnedByClick, Color.yellow);
    }
    public void PurchasableProductProducedGold (int amount, Vector3 position) {
        GoldAmount += amount;
        goldText.text = GoldAmount.ToString ("Gold: 0");
        goldUI.SpawnGoldText (position, amount, Color.yellow);
    }
    public void SpendGold (int cost) {
        GoldAmount -= cost;
        goldUI.SpawnGoldText (Input.mousePosition, -cost, Color.red);

    }
}