using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickUI : MonoBehaviour {
    public Button buyButton;
    bool _hoverOverButton;
    bool canBuyItem;
    void Update () {
        buyIndicator ();
    }
    public void ButtonPress (Button button) {
        GetComponent<GoldPress> ().ButtonName = button.name;
        GetComponent<GoldPress> ().CheckBuyItem (true);
    }
    public void HoverOverButton (Button button) {
        _hoverOverButton = !_hoverOverButton;
        if (_hoverOverButton) {
            GetComponent<GoldPress> ().ButtonName = button.name;
            GetComponent<GoldPress> ().CheckBuyItem (false);
        }
    }
    void buyIndicator () {
        if (_hoverOverButton) {
            canBuyItem = GetComponent<GoldPress> ().CanBuyItem;
            if (canBuyItem) {
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
}