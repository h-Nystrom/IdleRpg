using UnityEngine;

[RequireComponent (typeof (Lane), typeof (SpawnUnit))]
public class EnemySpawner : MonoBehaviour {
    public int level;
    public int maxSpawnCount;
    public Lane[] EnemyLanes;
    //Change to a scriptable object
    public int[] spawnRatePerLevel = new int[10];
    public int[] spawnCountPerLevel = new int[10];
    //
    int spawnRate;
    int spawnCount;
    float spawnTimer;

    void Start () {
        SpawnNewEnemyCommander ();
    }
    void Update () {
        CanSpawnUnit ();
    }
    void LevelUp () {
        level++;
        if (level < spawnRatePerLevel.Length) {
            spawnRate = spawnRatePerLevel[level];
            maxSpawnCount = spawnCountPerLevel[level];

        }
        spawnCount = 0;
        spawnTimer = Time.time;
    }
    public void SpawnNewEnemyCommander () {
        LevelUp ();
        GetComponent<SpawnUnit> ().Spawning (0);
    }
    void CanSpawnUnit () {
        if (Time.time - spawnTimer > spawnRate && spawnCount <= maxSpawnCount) {
            foreach (Lane lane in EnemyLanes) {
                if (!lane.IsFull) {
                    spawnCount++;
                    lane.GetComponent<SpawnUnit> ().Spawning (lane.unitsList.Count - 1);
                    spawnTimer = Time.time;
                    break;
                }
            }
            spawnTimer = Time.time;
        }
    }
}