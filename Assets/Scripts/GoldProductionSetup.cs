using TMPro;
using UnityEngine;

public class GoldProductionSetup : MonoBehaviour {
    public GoldProductionUnit goldProductionUnit;
    public TMP_Text goldAmountText;
    public TMP_Text purchaseButtonLabel;
    float timeDelay;

    public void SetUp (GoldProductionUnit goldProductionUnit) {
        this.goldProductionUnit = goldProductionUnit;
        this.gameObject.name = goldProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase price: {goldProductionUnit.CurrentPrice}gold";
        this.goldAmountText.text = $"{goldProductionUnit.name}: {goldProductionUnit.GoldGenerators}";
        timeDelay = goldProductionUnit.productionTime;
    }

    void Update () {
        if (goldProductionUnit.GoldGenerators != 0)
            MiningGold ();
    }
    void MiningGold () {
        if (Time.time - timeDelay >= goldProductionUnit.productionTime) {
            FindObjectOfType<Gold> ().UnitProducedGold (goldProductionUnit.GoldGenerators * goldProductionUnit.productionAmount, purchaseButtonLabel.transform.position);
            timeDelay = Time.time + goldProductionUnit.productionTime;
        }
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