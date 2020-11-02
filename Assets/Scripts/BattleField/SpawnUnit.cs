using UnityEngine;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour {
    public GameObject unitPrefab;
    public Transform IgnoreRaycastParent;
    public UnitType unitType;
    LaneManager laneManager;

    //Scriptable units
    public enum UnitType {
        PlayerCommander,
        EnemyCommander,
        EnemyUnit

    }
    void Start () {
        laneManager = FindObjectOfType<LaneManager> ();
    }
    //Change later to scriptable object
    public void Spawning (int siblingPosition) {
        GameObject newUnit = Instantiate (unitPrefab, this.transform);
        if (unitType == UnitType.PlayerCommander) {
            newUnit.GetComponent<FindTarget> ().attackLanes = laneManager.enemyLanes;
            newUnit.AddComponent<Commander> ();
        }
        if (unitType == UnitType.EnemyUnit || unitType == UnitType.EnemyCommander) {
            newUnit.GetComponent<FindTarget> ().attackLanes = laneManager.playerLanes;
            Destroy (newUnit.GetComponent<MoveUnit> ());
            newUnit.AddComponent<SpawnLoot> ();
            if (unitType == UnitType.EnemyCommander) {
                newUnit.AddComponent<EnemyCommander> ();
                newUnit.GetComponent<FindTarget> ().canAttack = false;
            } else {
                Commander commander = FindObjectOfType<Commander> ();
                Button button = newUnit.AddComponent<Button> ();
                button.transition = Selectable.Transition.None;
                button.onClick.AddListener (() => { commander.OnEnemyClick (newUnit.GetComponent<Unit> ()); });
            }
        }
        newUnit.GetComponent<UIIndicator> ().ignoreRaycastParent = IgnoreRaycastParent;
        newUnit.GetComponent<Unit> ().SetupUnit (transform, siblingPosition);
    }
}