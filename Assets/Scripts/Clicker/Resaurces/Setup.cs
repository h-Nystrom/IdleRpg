using UnityEngine;

namespace Clicker.Resources {
    public class Setup : MonoBehaviour {
        public Clicker.Resources.Resource[] resources;
        public Clicker.Resources.ResourceUI prefab;

        void Start () {
            foreach (var productionUnit in this.resources) {
                var instance = Instantiate (this.prefab, this.transform);
                instance.SetUp (productionUnit);
            }
        }
    }
}