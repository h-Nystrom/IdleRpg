using UnityEngine;
public class GoldMining : MonoBehaviour {
    float timeDelay = 1;
    [HideInInspector]
    public GoldProductionUnit goldProductionUnit;
    public MiningGoldpurchasableProduct miningGoldpurchasableProduct;
    public enum MiningGoldpurchasableProduct {
        GoldMiner,
        Bank,
        Marketplace,
        ChangeNameWhenAdded3,
        ChangeNameWhenAdded4
    }
    void Start () {
        goldProductionUnit = FindObjectOfType<GoldPress> ().goldProductionUnits[(int) miningGoldpurchasableProduct];
    }
    void Update () {
        if (goldProductionUnit.GoldGenerators != 0)
            MiningGold (goldProductionUnit);
    }
    void MiningGold (GoldProductionUnit goldProductionUnit) {
        if (Time.time - timeDelay >= goldProductionUnit.productionTime) {
            //FindObjectOfType<Gold> ().UnitProducedGold (goldProductionUnit.GoldGenerators * goldProductionUnit.productionAmount, goldProductionUnit.buttonTxtPosition.position);
            timeDelay = Time.time + goldProductionUnit.productionTime;
        }
    }
}