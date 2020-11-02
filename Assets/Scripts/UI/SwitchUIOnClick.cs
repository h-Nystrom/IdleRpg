using TMPro;
using UnityEngine;

public class SwitchUIOnClick : MonoBehaviour {
    public GameObject itemUI;
    public TMP_Text buttonTxt;
    bool _switchUI;
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