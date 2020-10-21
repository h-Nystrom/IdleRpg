using UnityEngine;

public class GoldUI : MonoBehaviour {
    public GameObject goldText;
    public void SpawnGoldText (Vector3 position, int amountOfGold, Color txtColor) {

        var newGoldText = Instantiate (goldText, position, Quaternion.identity, GameObject.FindGameObjectWithTag ("IgnoreRayCast").transform);
        newGoldText.GetComponent<TMPro.TMP_Text> ().text = amountOfGold.ToString ();
        newGoldText.GetComponent<TMPro.TMP_Text> ().color = txtColor;
    }

}