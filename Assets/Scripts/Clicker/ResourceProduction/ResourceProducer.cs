using Clicker.Resources;
using Common;
using TMPro;
using UnityEngine;

namespace Clicker.ResourceProduction {
    public class ResourceProducer : MonoBehaviour {
        public Data data;
        public TMP_Text titleText;
        public FloatingText popupPrefab;
        public Purchasable amount;
        public Purchasable upgrade;
        float elapsedTime;
        public void SetUp (Data data) {
            this.data = data;
            this.gameObject.name = data.name;
            this.amount.SetUp (data, "Buy");
            this.upgrade.SetUp (data, "Upgrade");
        }
        public void Purchase () => this.amount.Purchase ();
        public void Upgrade () => this.upgrade.Purchase ();
        void Update () {
            UpdateProduction ();
            UpdateTitleLabel ();
            this.amount.Update ();
            this.upgrade.Update ();
        }
        void UpdateProduction () {
            this.elapsedTime += Time.deltaTime;
            if (this.elapsedTime >= this.data.productionTime) {
                Produce ();
                this.elapsedTime -= this.data.productionTime;
            }
        }
        void UpdateTitleLabel () {
            this.titleText.text = $"{this.amount.Amount}x {this.data.name} Level {this.upgrade.Amount}";
        }
        void Produce () {
            if (this.amount.Amount == 0)
                return;
            var productionAmount = this.data.GetProductionAmount (this.upgrade.Amount, this.amount.Amount);
            productionAmount.Create ();
            var instance = Instantiate (this.popupPrefab, this.transform);
            instance.GetComponent<TMP_Text> ().text = $"+{productionAmount}";
        }
    }
}