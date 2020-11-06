using UnityEngine;
using UnityEngine.Serialization;

namespace Clicker.ResourceProduction {
    public class Setup : MonoBehaviour {

        public Data[] datas;
        public ResourceProducer prefab;

        void Start () {
            foreach (var productionUnit in this.datas) {
                var instance = Instantiate (this.prefab, this.transform);
                instance.SetUp (productionUnit);
            }
        }
    }
}