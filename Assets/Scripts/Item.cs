using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    static int _id = 0;
    public string name = "Name";
    public int price = 100;
    public int productionTime = 1;
    public int productionAmount = 1;
    public GameObject buyButton;
    int _goldGenerators = 0;
    public int Id { get => _id; }

    public Item () {
        _id++;
    }
    public int GoldGenerators {
        get => _goldGenerators;
        set => _goldGenerators = value;
    }
}