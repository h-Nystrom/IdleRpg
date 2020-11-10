using UnityEngine;

namespace Clicker.Resources {
    public class ResourceUI : MonoBehaviour {
        public TMPro.TMP_Text amountText;
        public Resource resource;
        public void SetUp (Resource resource) {
            this.resource = resource;
            this.amountText.text = this.resource.Amount.ToString ($"0 {this.resource.name}");
        }
        public void onProduce () => this.resource.Produce ();
        void UpdateAmountLabel () {
            this.amountText.text = this.resource.Amount.ToString ($"0 {this.resource.name}");
        }

        void Update () {
            UpdateAmountLabel ();
        }
    }
}