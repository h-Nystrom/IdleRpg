using UnityEngine;
using UnityEngine.EventSystems;

public class GoldPress : MonoBehaviour {

    public Item[] item;
    [HideInInspector]
    bool _canBuyItem;
    public bool CanBuyItem { get => _canBuyItem; }
    UpdateUI updateUI;
    void Start () {
        updateUI = GetComponent<UpdateUI> ();
    }
    public void BuyItem (int index) {
        item[index].GoldGenerators++;
        if (updateUI != null) {
            updateUI.UpdateText (index, item[index]);
        }
        FindObjectOfType<Gold> ().SpendGold (item[index].price);
    }
    public void CheckBuyItem (bool buy, string buttonName) {

        for (int i = 0; i < item.Length; i++) {
            if (buttonName == item[i].buyButton.name) {
                _canBuyItem = FindObjectOfType<Gold> ().GoldAmount >= item[i].price;
                if (buy && CanBuyItem) {
                    BuyItem (i);
                }

            }
        }
    }
}