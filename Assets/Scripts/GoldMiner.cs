using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldMiner : MonoBehaviour {

    int goldMiners;
    public int price = 100;
    public int productionTime = 1;
    public int productionGold = 1;
    public TMP_Text goldMinerTxt;
    public TMP_Text buttonTxt;
    public Button buyButton;
    bool _hoverOverButton;
    float timeDelay = 1;
    void Start () {
        goldMiners = PlayerPrefs.GetInt ("savedMiners", 0);
        goldMinerTxt.text = goldMiners.ToString ("Gold miners: 0");
        buttonTxt.text = $"Buy Gold miner: {price} gold";
    }
    void OnDestroy () {
        PlayerPrefs.SetInt ("savedMiners", goldMiners);
    }
    public bool CanBuyItem { get => FindObjectOfType<Gold> ().GoldAmount >= price; }
    public int GoldMiners { get => goldMiners; }
    void Update () {
        if (goldMiners == 0)
            return;

        MiningGold ();
        buyIndicator ();
    }
    public void HoverOverButton () {
        _hoverOverButton = !_hoverOverButton;
    }

    public void BuyItem () {
        if (CanBuyItem) {
            FindObjectOfType<Gold> ().SpendGold (price);
            AddGoldMiner ();
        }
    }
    void buyIndicator () {
        if (_hoverOverButton) {
            if (CanBuyItem) {
                changeButtonColor (Color.green);
            } else {
                changeButtonColor (Color.red);
            }
        }
    }
    void changeButtonColor (Color newPressedColor) {
        ColorBlock newColorBlock = buyButton.colors;
        newColorBlock.pressedColor = newPressedColor;
        buyButton.colors = newColorBlock;
    }
    public void AddGoldMiner () {
        goldMiners++;
        goldMinerTxt.text = goldMiners.ToString ("Gold miners: 0");
    }
    void MiningGold () {
        if (Time.time - timeDelay >= productionTime) {
            FindObjectOfType<Gold> ().ItemProducedGold (goldMiners * productionGold);
            timeDelay = Time.time + 1;
        }
    }
}