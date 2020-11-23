using Clicker.Resources;
using UnityEngine;

namespace Clicker.Resources {
    public class Setup : MonoBehaviour {
        public Resource[] resources;
        public ResourceUI prefab;

        void Start() {
            foreach (var productionUnit in this.resources) {
                var instance = Instantiate(this.prefab, this.transform);
                instance.SetUp(productionUnit);
            }
        }
    }
}