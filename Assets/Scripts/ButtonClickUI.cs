using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickUI : MonoBehaviour {
    Button buyButton;
    public bool _hoverOverButton;
    bool canBuyItem;
    void Update () {
        buyIndicator ();
    }
    public void ButtonPress (Button button) {

        GetComponent<GoldPress> ().CheckBuyItem (true, button.name);

    }
    public void HoverOverButton (Button button) {
        _hoverOverButton = !_hoverOverButton;
        if (_hoverOverButton) {
            GetComponent<GoldPress> ().CheckBuyItem (false, button.name);

            canBuyItem = GetComponent<GoldPress> ().CanBuyItem;
        } else {
            GetComponent<GoldPress> ().CheckBuyItem (false, null);
            canBuyItem = false;
        }
        buyButton = button;
    }
    void buyIndicator () {
        if (_hoverOverButton) {
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