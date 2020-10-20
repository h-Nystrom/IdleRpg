using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldMiner : MonoBehaviour {

    int goldMiners;
    public int price = 100;
    public TMP_Text goldMinerTxt;
    void Start () {
        goldMiners = PlayerPrefs.GetInt ("savedMiners");
        goldMinerTxt.text = goldMiners.ToString ("Gold miners: 0");
    }
    void OnDestroy () {
        PlayerPrefs.SetInt ("savedMiners", goldMiners);
    }
    void Update () {
        if (goldMiners > 0) {
            MiningGold ();
        }
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

    }
}