using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour {
    public int goldEarnedByClick = 5;
    int gold;

    void Start () {
        gold = PlayerPrefs.GetInt ("savedGold");
        GetComponent<TMP_Text> ().text = gold.ToString ("Gold: 0");
    }
    public void AddGold () {
        gold += goldEarnedByClick;
        GetComponent<TMP_Text> ().text = gold.ToString ("Gold: 0");
        PlayerPrefs.SetInt ("savedGold", gold);
    }

}