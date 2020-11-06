using UnityEngine;

public class UIIndicator : MonoBehaviour {
    public GameObject IndicatorPrefab;
    public void SpawnNewIndicator (Vector3 position, string message, bool lose) {
        var newText = Instantiate (IndicatorPrefab, position, Quaternion.identity, this.transform);
        newText.GetComponentInChildren<TMPro.TMP_Text> ().text = message;
        newText.GetComponentInChildren<Animator> ().SetBool ("Lose", lose);
    }
}