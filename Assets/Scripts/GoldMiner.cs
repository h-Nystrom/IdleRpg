using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldMiner : MonoBehaviour {

    int goldMiners;
    public int price = 100;
    public TMP_Text goldMinerTxt;
    float timeDelay = 1;
    void Start () {
        goldMiners = PlayerPrefs.GetInt ("savedMiners", 0);
        goldMinerTxt.text = goldMiners.ToString ("Gold miners: 0");
    }
    void OnDestroy () {
        PlayerPrefs.SetInt ("savedMiners", goldMiners);
    }
    void Update () {
        if (goldMiners == 0)
            return;
        MiningGold ();
    }
    public void BuyItem () {
        if (FindObjectOfType<Gold> ().CurrentGold >= price) {
            FindObjectOfType<Gold> ().SpendGold (price);
            AddGoldMiner ();
        }

    }
    public int GoldMiners { get => goldMiners; }
    public void AddGoldMiner () {
        goldMiners++;
        goldMinerTxt.text = goldMiners.ToString ("Gold miners: 0");

    }
    void MiningGold () {
        if (Time.time - timeDelay >= 1) {
            FindObjectOfType<Gold> ().ItemProducedGold (goldMiners);
            Debug.Log ("Gold");
            timeDelay = Time.time + 1;
        }
    }
}