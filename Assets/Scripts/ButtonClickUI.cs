using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickUI : MonoBehaviour {
    Button buyButton;
    public bool _hoverOverButton;
    bool canBuyPurchasableProduct;
    void Update () {
        buyIndicator ();
    }
    public void ButtonPress (Button button) {
        //GetComponent<GoldPress> ().CheckBuyItem (true, button.name);
        buyButton = button;
        canBuyPurchasableProduct = GetComponent<GoldPress> ().CanBuyPurchasableProducts;
    }
    public void HoverOverButton (Button button) {
        _hoverOverButton = !_hoverOverButton;
        if (_hoverOverButton) {
            buyButton = button;

        } else {
            canBuyPurchasableProduct = false;
            buyButton = null;
        }

    }
    void buyIndicator () {
        if (_hoverOverButton) {
            //GetComponent<GoldPress> ().CheckBuyItem (false, buyButton.name);
            if (canBuyPurchasableProduct) {
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