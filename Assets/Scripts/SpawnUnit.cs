using UnityEngine;

public class SpawnUnit : MonoBehaviour {
    public GameObject unitPrefab;
    public bool playerControlled;
    public bool spawnPlayerCommander;

    public void Spawning () {
        GameObject newUnit = Instantiate (unitPrefab, this.transform);
        if (!playerControlled) {
            newUnit.GetComponent<Unit> ().weaponRange = 3;
            Destroy (newUnit.GetComponent<MoveUnit> ());
            if (!spawnPlayerCommander)
                newUnit.GetComponent<FindTarget> ().playerControlled = false;
        }
        GetComponent<Lane> ().UpdateArray ();
        GetComponent<Lane> ().UpdateOpponentsLanes ();
    }
}