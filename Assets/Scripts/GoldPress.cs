using UnityEngine;
using UnityEngine.EventSystems;
public class GoldPress : MonoBehaviour {

    public Item[] item;
    bool _canBuyItem;
    string _buttonName;

    public string ButtonName { get => _buttonName; set => _buttonName = value; }
    public bool CanBuyItem { get => _canBuyItem; }
    public void BuyItem (int index) {
        item[index].GoldGenerators++;
        GetComponent<GoldMining> ().UpdateText ();
        FindObjectOfType<Gold> ().SpendGold (item[index].price);
        Debug.Log (item[index].Id);
    }
    public void CheckBuyItem (bool buy) {
        for (int i = 0; i < item.Length; i++) {
            if (ButtonName == item[i].buyButton.name) {
                _canBuyItem = FindObjectOfType<Gold> ().GoldAmount >= item[i].price;
                if (buy && CanBuyItem)
                    BuyItem (i);
            }
        }
    }
}