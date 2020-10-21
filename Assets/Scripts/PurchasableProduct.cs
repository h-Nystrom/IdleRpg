using UnityEngine;

[System.Serializable]
public class PurchasableProduct {
    static int _id = 0;
    public string name = "Name";
    public int startPrice = 100;
    public int productionTime = 1;
    public int procentageincreasePerGenerator = 10;
    public int productionAmount = 1;
    int _goldGenerators = 0;
    public int Id { get => _id; }

    public Transform buttonTxtPosition;

    public PurchasableProduct () {
        _id++;
    }
    public int CurrentPrice {
        get => startPrice + (_goldGenerators * procentageincreasePerGenerator);
    }
    public int GoldGenerators {
        get => _goldGenerators;
        set => _goldGenerators = value;
    }
}