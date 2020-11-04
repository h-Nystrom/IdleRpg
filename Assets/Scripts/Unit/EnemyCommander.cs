using UnityEngine;

public class EnemyCommander : MonoBehaviour {
    bool _isGameRunning = true;
    void OnDestroy () {
        if (_isGameRunning) {
            FindObjectOfType<SpawnUnit> ().SpawnEnemyCommander ();
        }
    }
    void OnApplicationQuit () {
        _isGameRunning = false;
    }
}