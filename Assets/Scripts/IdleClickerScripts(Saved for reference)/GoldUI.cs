using UnityEngine;

public class GoldUI : MonoBehaviour {
    public GameObject goldIndicator;
    public Transform ignoreRaycast;
    public void SpawnGoldText (Vector3 position, int amountOfGold, bool lose) {

        var newGoldText = Instantiate (goldIndicator, position, Quaternion.identity, ignoreRaycast);
        newGoldText.GetComponentInChildren<TMPro.TMP_Text> ().text = amountOfGold.ToString ("0g");
        newGoldText.GetComponentInChildren<Animator> ().SetBool ("Lose", lose);
    }

}