using UnityEngine;
using UnityEngine.UI;

public class GoldProductionUnits : MonoBehaviour {
    public GoldProductionUnit[] goldProductionUnits;
    public Transform unitParent;
    public GameObject goldProductionUnitPrefab;

    void Start () {
        foreach (var productionUnit in this.goldProductionUnits) {
            var instance = Instantiate (goldProductionUnitPrefab, unitParent);
            instance.GetComponent<GoldProductionScript> ().SetUp (productionUnit);
        }
    }
}