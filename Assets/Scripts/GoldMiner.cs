using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldMiner : MonoBehaviour {

    int goldMiners;
    public int price = 100;
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
        Debug.Log (_hoverOverButton);
    }

    public void BuyItem () {
        if (CanBuyItem) {
            FindObjectOfType<Gold> ().SpendGold (price);
            AddGoldMiner ();
        }
    }
    public void buyIndicator () {
        if (_hoverOverButton) {
            if (CanBuyItem) {
                changeButtonColor (Color.green, Color.grey);
            } else {
                changeButtonColor (Color.red, Color.magenta);
            }
        }
    }
    void changeButtonColor (Color newPressedColor, Color highlightedColor) {
        ColorBlock newColorBlock = buyButton.colors;
        newColorBlock.pressedColor = newPressedColor;
        newColorBlock.highlightedColor = highlightedColor;
        buyButton.colors = newColorBlock;
    }
    public void AddGoldMiner () {
        goldMiners++;
        goldMinerTxt.text = goldMiners.ToString ("Gold miners: 0");
    }
    void MiningGold () {
        if (Time.time - timeDelay >= 1) {
            FindObjectOfType<Gold> ().ItemProducedGold (goldMiners);
            timeDelay = Time.time + 1;
        }
    }
}