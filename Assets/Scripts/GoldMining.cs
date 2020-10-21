using UnityEngine;
public class GoldMining : MonoBehaviour {
    float timeDelay = 1;
    [HideInInspector]
    public PurchasableProduct purchasableProduct;
    public MiningGoldpurchasableProduct miningGoldpurchasableProduct;
    public enum MiningGoldpurchasableProduct {
        GoldMiner,
        Bank,
        ChangeNameWhenAdded2,
        ChangeNameWhenAdded3,
        ChangeNameWhenAdded4
    }
    void Start () {
        purchasableProduct = FindObjectOfType<GoldPress> ().purchasableProducts[(int) miningGoldpurchasableProduct];
    }
    void Update () {
        if (purchasableProduct.GoldGenerators != 0)
            MiningGold (purchasableProduct);
    }
    void MiningGold (PurchasableProduct purchasableProduct) {
        if (Time.time - timeDelay >= purchasableProduct.productionTime) {
            FindObjectOfType<Gold> ().PurchasableProductProducedGold (purchasableProduct.GoldGenerators * purchasableProduct.productionAmount);
            timeDelay = Time.time + purchasableProduct.productionTime;
        }
    }
}