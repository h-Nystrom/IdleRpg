using UnityEngine;

public class GoldUI : MonoBehaviour {
    public GameObject goldText;
    public void SpawnGoldText (Vector3 position, int amountOfGold, bool lose) {

        var newGoldText = Instantiate (goldText, position, Quaternion.identity, GameObject.FindGameObjectWithTag ("IgnoreRayCast").transform);
        newGoldText.GetComponentInChildren<TMPro.TMP_Text> ().text = amountOfGold.ToString ("0g");
        newGoldText.GetComponentInChildren<Animator> ().SetBool ("Lose", lose);
    }

}