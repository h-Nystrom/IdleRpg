using UnityEngine;

namespace Clicker.Resources {
    [CreateAssetMenu]
    public class Resource : ScriptableObject {
        public int amountPerClick = 5;

        public int Amount {
            get => PlayerPrefs.GetInt (this.name, 0);
            set => PlayerPrefs.SetInt (this.name, value);
        }

        public void Produce () {
            this.Amount += this.amountPerClick;
        }
    }
}