using UnityEngine;

[RequireComponent (typeof (Lane), typeof (SpawnUnit))]
public class SpawnCommander : MonoBehaviour {
    void Start () {
        GetComponent<SpawnUnit> ().Spawning (0);
        GetComponent<Lane> ().UpdateLane ();
    }
}