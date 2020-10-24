using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour {
    public GameObject ItemUIPrefab;
    const int maxIndex = 6; //Use SavedInventory Later
    void Awake () {
        SetUpItemSlots ();
    }
    void SetUpItemSlots () {
        for (int i = 0; i <= maxIndex; i++) {
            GameObject UnitUIButton = Instantiate (ItemUIPrefab, this.transform);
        }
    }
}