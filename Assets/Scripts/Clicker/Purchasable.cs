using System;
using UnityEngine;

namespace Clicker {
    [Serializable]
    public class Purchasable {
        public TMPro.TMP_Text buttonLabel;
        ResourceProduction.Data data;
        ResourcesIdleClicker.Resource resource;
        string productId;

        bool IsAffordable => this.resource.Amount >= this.data.GetActualCosts (this.Amount);

        public int Amount {
            get => PlayerPrefs.GetInt (this.data.name + "_" + this.productId, 0);
            private set => PlayerPrefs.SetInt (this.data.name + "_" + this.productId, value);
        }

        public void SetUp (ResourceProduction.Data data, ResourcesIdleClicker.Resource resource, string productId) {
            this.data = data;
            this.resource = resource;
            this.productId = productId;
            this.buttonLabel.text = $"Add {productId} for {data.GetActualCosts(this.Amount)} {resource.name}";
        }

        public void Purchase () {
            if (!this.IsAffordable)
                return;
            this.resource.Amount -= this.data.GetActualCosts (this.Amount);
            this.Amount += 1;
            this.buttonLabel.text = $"Add {this.productId} for {this.data.GetActualCosts(this.Amount)} {this.resource.name}";
        }

        public void Update () => UpdateTextColor ();
        void UpdateTextColor () => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
    }
}