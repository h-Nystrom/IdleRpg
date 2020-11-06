using UnityEngine;

public class SpawnLoot : MonoBehaviour {
    public GameObject itemPrefab;
    //Scriptable objects (items)
    public int goldDrop = 50;
    bool _isGameRunning = true;
    UIIndicator uIIndicator;
    void Start () {
        uIIndicator = FindObjectOfType<UIIndicator> ();
    }
    void OnDestroy () {
        if (_isGameRunning) {
            uIIndicator.SpawnNewIndicator (transform.position, $"+{goldDrop}gold", false);
            FindObjectOfType<GoldScript> ().Amount = goldDrop;
        }
    }
    void OnApplicationQuit () {
        _isGameRunning = false;
    }
}