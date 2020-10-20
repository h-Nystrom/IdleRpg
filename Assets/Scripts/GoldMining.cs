using UnityEngine;
public class GoldMining : MonoBehaviour {
    float timeDelay = 1;

    Item[] items;
    void Start () {
        items = GetComponent<GoldPress> ().item;
    }
    void Update () {
        if (items[0].GoldGenerators != 0)
            MiningGold (items[0]);
        if (items[1].GoldGenerators != 0)
            MiningGold (items[1]);
    }
    void MiningGold (Item item) {
        if (Time.time - timeDelay >= item.productionTime) {
            FindObjectOfType<Gold> ().ItemProducedGold (item.GoldGenerators * item.productionAmount);
            timeDelay = Time.time + 1;
            Debug.Log (item.name);
        }
    }
}