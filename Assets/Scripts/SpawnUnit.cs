using UnityEngine;

public class SpawnUnit : MonoBehaviour {
    public GameObject unitPrefab;
    public bool playerControlled;
    public bool spawnPlayerCommander;

    public void Spawning () {
        GameObject newUnit = Instantiate (unitPrefab, this.transform);
        if (!playerControlled) {
            Destroy (newUnit.GetComponent<MoveUnit> ());
            if (!spawnPlayerCommander)
                newUnit.GetComponent<FindTarget> ().playerControlled = false;
        }
        GetComponent<Lane> ().UpdateArray ();
        //Update all opponents lanes!
    }
}