using UnityEngine;

public class EnemyCommander : MonoBehaviour {
    [HideInInspector] public SpawnEnemyUnits spawnEnemyUnits;
    bool _isGameRunning = true;
    void OnDestroy () {
        if (_isGameRunning) {
            spawnEnemyUnits.Invoke ("SpawnEnemyCommander", 2f);
        }
    }
    void OnApplicationQuit () {
        _isGameRunning = false;
    }
}