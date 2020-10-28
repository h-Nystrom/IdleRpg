using UnityEngine;

public class SpawnUnit : MonoBehaviour {
    public GameObject unitPrefab;
    public Transform IgnoreRaycastParent;
    public bool playerControlled;
    public bool spawnPlayerCommander;

    public void Spawning (int siblingPosition) {
        GameObject newUnit = Instantiate (unitPrefab, this.transform);
        newUnit.GetComponent<Unit> ().SetupUnit (transform, siblingPosition);
        if (!playerControlled) {
            newUnit.GetComponent<UIIndicator> ().ignoreRaycastParent = IgnoreRaycastParent;
            Destroy (newUnit.GetComponent<MoveUnit> ());
            if (!spawnPlayerCommander)
                newUnit.GetComponent<FindTarget> ().playerControlled = false;
        }
    }
}