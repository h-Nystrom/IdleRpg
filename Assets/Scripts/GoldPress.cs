using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GoldPress : MonoBehaviour {
    public string name;
    public int price = 100;
    public int productionTime = 1;
    public int productionGold = 1;
    public TMP_Text goldGeneratorTxt;
    public TMP_Text buttonTxt;
    public Button buyButton;
    int _goldGenerators;
    bool _hoverOverButton;
    float timeDelay = 1;

    void Start () {
        GoldGenerators = PlayerPrefs.GetInt ("savedGenerators", 0);
        goldGeneratorTxt.text = GoldGenerators.ToString ($"{name}: 0");
        buttonTxt.text = $"Buy {name}: {price} gold";
    }
    void OnDestroy () {
        PlayerPrefs.SetInt ("savedGenerators", GoldGenerators);
    }
    public bool CanBuyItem { get => FindObjectOfType<Gold> ().GoldAmount >= price; }
    public int GoldGenerators { get => _goldGenerators; set => _goldGenerators = value; }
    void Update () {
        if (GoldGenerators == 0)
            return;

        MiningGold ();
        buyIndicator ();
    }
    public void HoverOverButton () {
        _hoverOverButton = !_hoverOverButton;
    }

    public void BuyItem () {
        if (CanBuyItem) {
            FindObjectOfType<Gold> ().SpendGold (price);
            AddGoldMiner ();
        }
    }
    void buyIndicator () {
        if (_hoverOverButton) {
            if (CanBuyItem) {
                changeButtonColor (Color.green);
            } else {
                changeButtonColor (Color.red);
            }
        }
    }
    void changeButtonColor (Color newPressedColor) {
        ColorBlock newColorBlock = buyButton.colors;
        newColorBlock.pressedColor = newPressedColor;
        buyButton.colors = newColorBlock;
    }
    public void AddGoldMiner () {
        GoldGenerators++;
        goldGeneratorTxt.text = GoldGenerators.ToString ($"{name}: 0");
    }
    void MiningGold () {
        if (Time.time - timeDelay >= productionTime) {
            FindObjectOfType<Gold> ().ItemProducedGold (GoldGenerators * productionGold);
            timeDelay = Time.time + 1;
        }
    }
}