using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour {
    int gold;
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    public void AddGold () {
        gold += 5;
        GetComponent<TMP_Text> ().text = gold.ToString ("Gold: 0");
    }

}