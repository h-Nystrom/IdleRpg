using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GoldMining : MonoBehaviour {
    float timeDelay = 1;
    public TMP_Text goldGeneratorTxt;
    public TMP_Text buttonTxt;

    [HideInInspector]
    public Item item;
    void Start () {
        item = GetComponent<GoldPress> ().item[0];
        item.GoldGenerators = PlayerPrefs.GetInt ("savedGenerators", 0);
        goldGeneratorTxt.text = GoldGenerators.ToString ($"{item.name}: 0");
        buttonTxt.text = $"Buy {item.name}: {item.price} gold";
    }
    void OnDestroy () {
        PlayerPrefs.SetInt ("savedGenerators", GoldGenerators);
    }
    public int GoldGenerators {
        get => item.GoldGenerators;
    }
    public void UpdateText () {
        goldGeneratorTxt.text = GoldGenerators.ToString ($"{item.name}: 0");
    }
    void Update () {
        if (GoldGenerators == 0)
            return;
        MiningGold ();
    }
    void MiningGold () {
        if (Time.time - timeDelay >= item.productionTime) {
            //goldGeneratorTxt.text = GoldGenerators.ToString ($"{item.name}: 0");
            FindObjectOfType<Gold> ().ItemProducedGold (GoldGenerators * item.productionAmount);
            timeDelay = Time.time + 1;
        }
    }
}