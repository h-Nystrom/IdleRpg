using UnityEngine;

[System.Serializable]
public class GoldProductionData {
    public string name = "Name";
    public int startPrice = 100;
    public int productionTime = 1;
    public float percentageIncrease = 10;
    public int productionAmount = 1;
    int _goldGenerators = 0;
    int _id;
    public static int Id;

    public GoldProductionData () {
        Id++;
        _id = Id;
    }
    public int ID {
        get => _id;
    }
    float PercentToDecimal { get => (percentageIncrease * 0.01f) + 1; }
    public int CurrentPrice { get => (int) (startPrice * Mathf.Pow (PercentToDecimal, _goldGenerators)); }
    public int CurrentProductionAmount { get => (int) (productionAmount * Mathf.Pow (PercentToDecimal, _goldGenerators)); }
    public int GoldGenerators {
        get => _goldGenerators;
        set => _goldGenerators = value;
    }
}