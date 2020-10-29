using UnityEngine;

public class SpawnUnit : MonoBehaviour {
    public GameObject unitPrefab;
    public Transform IgnoreRaycastParent;
    public UnitType unitType;
    LaneManager laneManager;
    public enum UnitType {
        PlayerCommander,
        EnemyCommander,
        EnemyUnit

    }
    void Start () {
        laneManager = FindObjectOfType<LaneManager> ();
    }
    public void Spawning (int siblingPosition) {
        GameObject newUnit = Instantiate (unitPrefab, this.transform);
        if (unitType == UnitType.PlayerCommander) {
            newUnit.GetComponent<FindTarget> ().attackLanes = laneManager.enemyLanes;
        }
        if (unitType == UnitType.EnemyUnit || unitType == UnitType.EnemyCommander) {
            newUnit.GetComponent<UIIndicator> ().ignoreRaycastParent = IgnoreRaycastParent;
            newUnit.GetComponent<FindTarget> ().attackLanes = laneManager.playerLanes;
            Destroy (newUnit.GetComponent<MoveUnit> ());
            if (unitType == UnitType.EnemyCommander) {
                newUnit.AddComponent<EnemyCommander> ();
                newUnit.GetComponent<FindTarget> ().canAttack = false;
            }
        }
        newUnit.GetComponent<Unit> ().SetupUnit (transform, siblingPosition);
    }
}