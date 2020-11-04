using UnityEngine;

[RequireComponent (typeof (Lane), typeof (SpawnUnit))]
public class EnemySpawner : MonoBehaviour {
    public int level;
    public int maxSpawnCount;
    public Lane[] EnemyLanes;
    public int[] spawnRatePerLevel = new int[10];
    public int[] spawnCountPerLevel = new int[10];
    int spawnRate;
    int spawnCount;
    float spawnTimer;

    void LevelUp () {
        level++;
        if (level < spawnRatePerLevel.Length) {
            spawnRate = spawnRatePerLevel[level];
            maxSpawnCount = spawnCountPerLevel[level];
        }
        spawnCount = 0;
        spawnTimer = Time.time;
    }
    void CanSpawnUnit () {
        if (Time.time - spawnTimer > spawnRate && spawnCount <= maxSpawnCount) {
            foreach (Lane lane in EnemyLanes) {
                if (!lane.IsFull) {
                    spawnCount++;
                    //lane.GetComponent<SpawnUnit> ().SpawningEnemyUnits(lane.unitsList.Count - 1);
                    spawnTimer = Time.time;
                    break;
                }
            }
            spawnTimer = Time.time;
        }
    }
    void Update () {
        CanSpawnUnit ();
    }

}