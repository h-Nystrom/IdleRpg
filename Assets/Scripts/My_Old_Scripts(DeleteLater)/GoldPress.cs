using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent (typeof (UpdateGoldPressUI))]
public class GoldPress : MonoBehaviour {

    public GoldProductionUnit[] goldProductionUnits;
    public bool _hoverOverButton;
    bool _canBuyGoldProductionUnit;

    UpdateGoldPressUI updateGoldPressUI;
    Button buyButton;
    int hoverButtonIndex;
    public bool CanBuyGoldProductionUnit { get => _canBuyGoldProductionUnit; }
    void Start () {
        updateGoldPressUI = GetComponent<UpdateGoldPressUI> ();
    }
    void Update () {
        buyIndicator ();
    }
    public void BuyGoldProductionUnit (int index) {

        if (CanBuyGoldProductionUnit) {
            FindObjectOfType<Gold> ().SpendGold (goldProductionUnits[index].CurrentPrice);
            goldProductionUnits[index].GoldGenerators++;
            if (updateGoldPressUI != null) {
                updateGoldPressUI.UpdateText (index, goldProductionUnits[index]);
            }
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
            _canBuyGoldProductionUnit = FindObjectOfType<Gold> ().GoldAmount >= goldProductionUnits[hoverButtonIndex].CurrentPrice;
            if (CanBuyGoldProductionUnit) {
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