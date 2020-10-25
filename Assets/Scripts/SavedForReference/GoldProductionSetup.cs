using UnityEngine;
using UnityEngine.UI;

public class GoldProductionSetup : MonoBehaviour {
    public GoldProductionData[] goldProductionData;
    public Transform unitParent;
    public GameObject goldProductionUnitPrefab;

    void Start () {
        foreach (var productionData in this.goldProductionData) {
            var instance = Instantiate (goldProductionUnitPrefab, unitParent);
            instance.GetComponent<GoldProducer> ().SetUp (productionData);
        }
    }
}