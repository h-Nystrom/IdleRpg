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
        Vector3 offset = new Vector3 (Random.Range (-10, 10), Random.Range (-10, 10), 0);
        goldUI.SpawnGoldText (Input.mousePosition + offset, goldEarnedByClick, false);
    }
    public void PurchasableProductProducedGold (int amount, Vector3 position) {
        GoldAmount += amount;
        goldText.text = GoldAmount.ToString ("Gold: 0");
        Vector3 offset = new Vector3 (Random.Range (-100, 100), Random.Range (-5, 5), 0);
        goldUI.SpawnGoldText (position + offset, amount, false);
    }
    public void SpendGold (int cost) {
        GoldAmount -= cost;
        goldUI.SpawnGoldText (Input.mousePosition, -cost, true);

    }
}