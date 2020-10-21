using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateGoldPressUI : MonoBehaviour {
    public TMP_Text[] goldGeneratorTxt;
    public TMP_Text[] buttonTxt;

    void Start () {
        int i = 0;
        foreach (GoldProductionUnit goldProductionUnit in GetComponent<GoldPress> ().goldProductionUnits) {
            goldProductionUnit.GoldGenerators = PlayerPrefs.GetInt (goldProductionUnit.name, 0);
            goldGeneratorTxt[i].text = $"{goldProductionUnit.name}: {goldProductionUnit.GoldGenerators} ({goldProductionUnit.CurrentProductionAmount}gold/{goldProductionUnit.productionTime}s)";
            buttonTxt[i].text = $"Buy {goldProductionUnit.name}: {goldProductionUnit.CurrentPrice} gold";
            i++;
        }
    }
    void Update () {
        if (Input.GetKeyDown (KeyCode.Q)) {
            PlayerPrefs.DeleteAll ();
            int i = 0;
            foreach (GoldProductionUnit goldProductionUnit in GetComponent<GoldPress> ().goldProductionUnits) {
                goldProductionUnit.GoldGenerators = PlayerPrefs.GetInt (goldProductionUnit.name, 0);
                goldGeneratorTxt[i].text = $"{goldProductionUnit.name}: {goldProductionUnit.GoldGenerators} ({goldProductionUnit.CurrentProductionAmount}gold/{goldProductionUnit.productionTime}s)";
                buttonTxt[i].text = $"Buy {goldProductionUnit.name}: {goldProductionUnit.CurrentPrice} gold";
                i++;
            }
        }
        if (Input.GetKeyDown (KeyCode.W)) {
            foreach (GoldProductionUnit goldProductionUnit in GetComponent<GoldPress> ().goldProductionUnits) {
                Debug.Log (goldProductionUnit.name + " " + PlayerPrefs.GetInt (goldProductionUnit.name, goldProductionUnit.GoldGenerators));
            }
        }
    }
    void OnDestroy () {
        foreach (GoldProductionUnit goldProductionUnit in GetComponent<GoldPress> ().goldProductionUnits) {
            PlayerPrefs.SetInt (goldProductionUnit.name, goldProductionUnit.GoldGenerators);
        }
    }
    public void UpdateText (int index, GoldProductionUnit goldProductionUnit) {
        //goldGeneratorTxt[index].text = purchasableProduct.GoldGenerators.ToString ($"{purchasableProduct.name}: 0");
        goldGeneratorTxt[index].text = $"{goldProductionUnit.name}: {goldProductionUnit.GoldGenerators} ({goldProductionUnit.CurrentProductionAmount}gold/{goldProductionUnit.productionTime}s)";
        buttonTxt[index].text = $"Buy {goldProductionUnit.name}: {goldProductionUnit.CurrentPrice} gold";
    }
}