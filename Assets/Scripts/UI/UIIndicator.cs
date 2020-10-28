using UnityEngine;

public class UIIndicator : MonoBehaviour {
    public GameObject IndicatorPrefab;
    public Transform ignoreRaycastParent;
    void Start () {

    }

    public void SpawnNewIndicator (Vector3 position, string message, bool lose) {

        var newText = Instantiate (IndicatorPrefab, position, Quaternion.identity, ignoreRaycastParent);
        newText.GetComponentInChildren<TMPro.TMP_Text> ().text = message;
        newText.GetComponentInChildren<Animator> ().SetBool ("Lose", lose);
    }
}