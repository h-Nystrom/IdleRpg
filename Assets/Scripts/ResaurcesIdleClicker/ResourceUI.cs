using UnityEngine;

namespace ResourcesIdleClicker {
    public class ResourceUI : MonoBehaviour {
        public TMPro.TMP_Text amountText;
        public Resource resource;

        void UpdateAmountLabel () {
            this.amountText.text = this.resource.Amount.ToString ($"0 {this.resource.name}");
        }

        void Update () {
            UpdateAmountLabel ();
        }
    }
}