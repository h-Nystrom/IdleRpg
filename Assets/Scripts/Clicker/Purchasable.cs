using System;
using Clicker.ResourceProduction;
using UnityEngine;

namespace Clicker {
    [Serializable]
    public class Purchasable {
        public TMPro.TMP_Text buttonLabel;
        Data data;
        string productId;
        bool IsAffordable => this.data.GetActualCosts(this.Amount).IsAffordable;

        public int Amount {
            get => PlayerPrefs.GetInt(this.data.name + "_" + this.productId, 0);
            private set => PlayerPrefs.SetInt(this.data.name + "_" + this.productId, value);
        }
        public void SetUp(Data data, string productId) {
            this.data = data;
            this.productId = productId;
            if (productId == "Upgrade" && Amount == 0)
                Amount++;
            UpdateCostLabel();
        }
        public void Purchase() {
            if (!this.IsAffordable)
                return;
            this.data.GetActualCosts(this.Amount).Consume();
            this.Amount += 1;
            UpdateCostLabel();
        }
        void UpdateCostLabel() {
            var updatedCost = this.data.GetActualCosts(this.Amount);
            this.buttonLabel.text = $"{productId} {data.name} for {updatedCost.ToString ()}";
        }
        public void Update() => UpdateTextColor();
        void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
    }
}