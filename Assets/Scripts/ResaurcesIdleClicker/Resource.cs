using UnityEngine;

namespace ResourcesIdleClicker {
    [CreateAssetMenu]
    public class Resource : ScriptableObject {
        public int amountPerClick = 5;

        // increases the amount of this Resource
        public int Amount {
            get => PlayerPrefs.GetInt (this.name, 1);
            set => PlayerPrefs.SetInt (this.name, value);
        }

        public void Produce () {
            this.Amount += this.amountPerClick;
        }
    }
}