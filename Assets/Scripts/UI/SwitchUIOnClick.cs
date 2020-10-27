using TMPro;
using UnityEngine;

public class SwitchUIOnClick : MonoBehaviour {
    bool _switchUI;
    public GameObject itemUI;
    public TMP_Text buttonTxt;

    public void SwitchOnClick () {
        _switchUI = !_switchUI;
        if (_switchUI) {
            itemUI.SetActive (true);
            buttonTxt.text = "Units";
        } else {
            itemUI.SetActive (false);
            buttonTxt.text = "Items";
        }
    }
}