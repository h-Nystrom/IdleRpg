using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldProductionScript : MonoBehaviour {
    public GoldProductionUnit goldProductionUnit;
    public TMP_Text goldAmountText;
    public TMP_Text purchaseButtonLabel;
    public Button buyButton;
    float timeDelay;
    bool _canBuyUnit;
    bool _hoverOverButton;
    public bool CanBuyUnit { get => _canBuyUnit; }
    public void SetUp (GoldProductionUnit goldProductionUnit) {
        this.goldProductionUnit = goldProductionUnit;
        this.gameObject.name = goldProductionUnit.name;
        this.goldProductionUnit.GoldGenerators = PlayerPrefs.GetInt (goldProductionUnit.name, 0);
        this.purchaseButtonLabel.text = $"Purchase price: {goldProductionUnit.CurrentPrice}gold";
        this.goldAmountText.text = $"{goldProductionUnit.name}: {goldProductionUnit.GoldGenerators}";
        this.timeDelay = goldProductionUnit.productionTime;
    }
    void OnDestroy () {
        PlayerPrefs.SetInt (goldProductionUnit.name, goldProductionUnit.GoldGenerators);
    }
    void Update () {
        if (goldProductionUnit.GoldGenerators != 0)
            MiningGold ();

        buyIndicator ();
    }
    void MiningGold () {
        if (Time.time - timeDelay >= goldProductionUnit.productionTime) {
            FindObjectOfType<Gold> ().UnitProducedGold (goldProductionUnit.GoldGenerators * goldProductionUnit.productionAmount, purchaseButtonLabel.transform.position);
            timeDelay = Time.time + goldProductionUnit.productionTime;
        }
    }
    void UpdateUnitUI () {
        this.purchaseButtonLabel.text = $"Purchase price: {goldProductionUnit.CurrentPrice}gold";
        this.goldAmountText.text = $"{goldProductionUnit.name}: {goldProductionUnit.GoldGenerators}";
    }
    public void BuyGoldProductionUnit () {
        if (_canBuyUnit) {
            FindObjectOfType<Gold> ().SpendGold (goldProductionUnit.CurrentPrice);
            goldProductionUnit.GoldGenerators++;
            UpdateUnitUI ();
        }
    }
    public void HoverOverButton (Button button) {
        if (buyButton = button) {
            _hoverOverButton = !_hoverOverButton;
        }

    }
    void buyIndicator () {
        if (_hoverOverButton) {
            _canBuyUnit = FindObjectOfType<Gold> ().GoldAmount >= goldProductionUnit.CurrentPrice;
            if (_canBuyUnit) {
                changeButtonColor (Color.green);
            } else {
                changeButtonColor (Color.red);
            }
        }
    }
    void changeButtonColor (Color highLightedColor) {
        ColorBlock colorBlock = buyButton.colors;
        colorBlock.highlightedColor = highLightedColor;
        buyButton.colors = colorBlock;
    }
    /*
    public int GoldPressAmount {
        get => PlayerPrefs.GetInt (this.goldProductionUnit.name, 0);
        set {
            PlayerPrefs.SetInt (this.goldProductionUnit.name, value);
            UpdateGoldPressAmountLabel ();
        }
    }

    void UpdateGoldPressAmountLabel () {
        this.goldAmountText.text = this.GoldPressAmount.ToString ($"0 {this.goldProductionUnit.name}");
    }
    /*
        void Start () {
            UpdateGoldPressAmountLabel ();
        }

        void Update () {
            this.elapsedTime += Time.deltaTime;
            if (this.elapsedTime >= this.goldProductionUnit.productionTime) {
                ProduceGold ();
                this.elapsedTime -= this.goldProductionUnit.productionTime;
            }
        }
        void ProduceGold () {
            var gold = FindObjectOfType<Gold> ();
            gold.GoldAmount += this.goldProductionUnit.productionAmount * this.GoldPressAmount;
        }

        public void BuyGoldPress () {
            var gold = FindObjectOfType<Gold> ();
            if (gold.GoldAmount >= this.goldProductionUnit.CurrentPrice) {
                gold.GoldAmount -= this.goldProductionUnit.CurrentPrice;
                this.GoldPressAmount += 1;
            }
        }
        */
}