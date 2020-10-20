using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent (typeof (UpdateUI))]
public class UpdateUI : MonoBehaviour {
    public TMP_Text[] goldGeneratorTxt;
    public TMP_Text[] buttonTxt;
    void Start () {
        int i = 0;
        foreach (Item item in GetComponent<GoldPress> ().item) {
            item.GoldGenerators = PlayerPrefs.GetInt (item.name, 0);
            goldGeneratorTxt[i].text = item.GoldGenerators.ToString ($"{item.name}: 0");
            buttonTxt[i].text = $"Buy {item.name}: {item.price} gold";
            i++;
        }
    }
    void Update () {
        if (Input.GetKeyDown (KeyCode.Q)) {
            PlayerPrefs.DeleteAll ();
            int i = 0;
            foreach (Item item in GetComponent<GoldPress> ().item) {
                item.GoldGenerators = PlayerPrefs.GetInt (item.name, 0);
                goldGeneratorTxt[i].text = item.GoldGenerators.ToString ($"{item.name}: 0");
                buttonTxt[i].text = $"Buy {item.name}: {item.price} gold";
                i++;
            }
        }
        if (Input.GetKeyDown (KeyCode.W)) {
            foreach (Item item in GetComponent<GoldPress> ().item) {
                Debug.Log (item.name + " " + PlayerPrefs.GetInt (item.name, item.GoldGenerators));
            }
        }
    }
    void OnDestroy () {
        foreach (Item item in GetComponent<GoldPress> ().item) {
            PlayerPrefs.SetInt (item.name, item.GoldGenerators);
        }
    }
    public void UpdateText (int index, Item item) {
        goldGeneratorTxt[index].text = item.GoldGenerators.ToString ($"{item.name}: 0");
    }
}