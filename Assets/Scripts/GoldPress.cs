using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent (typeof (UpdateGoldPressUI))]
public class GoldPress : MonoBehaviour {

    public PurchasableProduct[] purchasableProducts;
    public bool _hoverOverButton;
    bool _canBuyPurchasableProducts;

    UpdateGoldPressUI updateGoldPressUI;
    Button buyButton;
    int hoverButtonIndex;
    public bool CanBuyPurchasableProducts { get => _canBuyPurchasableProducts; }
    void Start () {
        updateGoldPressUI = GetComponent<UpdateGoldPressUI> ();
    }
    void Update () {
        buyIndicator ();
    }
    public void BuypurchasableProducts (int index) {

        if (CanBuyPurchasableProducts) {
            purchasableProducts[index].GoldGenerators++;
            if (updateGoldPressUI != null) {
                updateGoldPressUI.UpdateText (index, purchasableProducts[index]);
            }
            FindObjectOfType<Gold> ().SpendGold (purchasableProducts[index].price);
        }
    }
    public void GetButton (Button button) {
        buyButton = button;
    }
    public void HoverOverButton (int index) {
        _hoverOverButton = !_hoverOverButton;
        if (_hoverOverButton)
            hoverButtonIndex = index;
        else
            hoverButtonIndex = 100;
    }
    void buyIndicator () {
        if (_hoverOverButton && hoverButtonIndex != 100) {
            _canBuyPurchasableProducts = FindObjectOfType<Gold> ().GoldAmount >= purchasableProducts[hoverButtonIndex].price;
            if (CanBuyPurchasableProducts) {
                changeButtonColor (Color.green);
            } else {
                changeButtonColor (Color.red);
            }
        }
    }
    void changeButtonColor (Color highLightedColor) {
        ColorBlock colorBlock = buyButton.colors;
        colorBlock.highlightedColor = highLightedColor;
        buyButton.colors = colorBlock;
    }
}