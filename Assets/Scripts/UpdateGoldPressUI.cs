using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent (typeof (GoldPress))]
public class UpdateGoldPressUI : MonoBehaviour {
    public TMP_Text[] goldGeneratorTxt;
    public TMP_Text[] buttonTxt;

    void Start () {
        int i = 0;
        foreach (PurchasableProduct purchasableProduct in GetComponent<GoldPress> ().purchasableProducts) {
            purchasableProduct.GoldGenerators = PlayerPrefs.GetInt (purchasableProduct.name, 0);
            goldGeneratorTxt[i].text = purchasableProduct.GoldGenerators.ToString ($"{purchasableProduct.name}: 0");
            buttonTxt[i].text = $"Buy {purchasableProduct.name}: {purchasableProduct.CurrentPrice} gold";
            i++;
        }
    }
    void Update () {
        if (Input.GetKeyDown (KeyCode.Q)) {
            PlayerPrefs.DeleteAll ();
            int i = 0;
            foreach (PurchasableProduct purchasableProduct in GetComponent<GoldPress> ().purchasableProducts) {
                purchasableProduct.GoldGenerators = PlayerPrefs.GetInt (purchasableProduct.name, 0);
                goldGeneratorTxt[i].text = purchasableProduct.GoldGenerators.ToString ($"{purchasableProduct.name}: 0");
                buttonTxt[i].text = $"Buy {purchasableProduct.name}: {purchasableProduct.CurrentPrice} gold";
                i++;
            }
        }
        if (Input.GetKeyDown (KeyCode.W)) {
            foreach (PurchasableProduct purchasableProduct in GetComponent<GoldPress> ().purchasableProducts) {
                Debug.Log (purchasableProduct.name + " " + PlayerPrefs.GetInt (purchasableProduct.name, purchasableProduct.GoldGenerators));
            }
        }
    }
    void OnDestroy () {
        foreach (PurchasableProduct purchasableProduct in GetComponent<GoldPress> ().purchasableProducts) {
            PlayerPrefs.SetInt (purchasableProduct.name, purchasableProduct.GoldGenerators);
        }
    }
    public void UpdateText (int index, PurchasableProduct purchasableProduct) {
        goldGeneratorTxt[index].text = purchasableProduct.GoldGenerators.ToString ($"{purchasableProduct.name}: 0");
        buttonTxt[index].text = $"Buy {purchasableProduct.name}: {purchasableProduct.CurrentPrice} gold";
    }
}