using UnityEngine;

public class EnemyCommander : MonoBehaviour {
    public EnemySpawner enemySpawner;
    bool _isGameRunning = true;
    void OnDestroy () {
        if (_isGameRunning) {
            FindObjectOfType<EnemySpawner> ().SpawnNewEnemyCommander ();
        }
    }
    void OnApplicationQuit () {
        _isGameRunning = false;
    }
}