using UnityEngine;

[RequireComponent (typeof (Lane), typeof (SpawnUnit))]
public class EnemySpawner : MonoBehaviour {
    public int level;
    public int maxSpawnCount;
    //Change to a scriptable object
    public int[] spawnRatePerLevel = new int[10];
    public int[] spawnCountPerLevel = new int[10];
    //
    int spawnRate;
    int spawnCount;
    float spawnTimer;
    int maxUnits;

    void Start () {
        maxUnits = GetComponent<Lane> ().maxUnits;
        LevelUp ();
    }
    void Update () {
        CanSpawnUnit ();
    }
    void LevelUp () {
        if (level <= spawnRatePerLevel.Length) {
            spawnRate = spawnRatePerLevel[level];
            maxSpawnCount = spawnCountPerLevel[level];
            spawnCount = 0;
            spawnTimer = Time.time;
        }

    }
    void CanSpawnUnit () {

        if (Time.time - spawnTimer > spawnRate) {
            if (GetComponent<Lane> ().unitsList.Count < maxUnits) {
                spawnCount++;
                GetComponent<SpawnUnit> ().Spawning (GetComponent<Lane> ().unitsList.Count - 1);
                if (spawnCount >= maxSpawnCount) {
                    LevelUp ();
                } else {
                    spawnTimer = Time.time;
                }
            } else {
                spawnTimer = Time.time;
            }
        }
    }
}