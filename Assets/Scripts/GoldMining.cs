using UnityEngine;
public class GoldMining : MonoBehaviour {
    float timeDelay = 1;
    [HideInInspector]
    public PurchasableProduct purchasableProduct;
    public MiningGoldpurchasableProduct miningGoldpurchasableProduct;
    public enum MiningGoldpurchasableProduct {
        GoldMiner,
        Bank,
        Marketplace,
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
            FindObjectOfType<Gold> ().PurchasableProductProducedGold (purchasableProduct.GoldGenerators * purchasableProduct.productionAmount, purchasableProduct.buttonTxtPosition.position);
            timeDelay = Time.time + purchasableProduct.productionTime;
        }
    }
}