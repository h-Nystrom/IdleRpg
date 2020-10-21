using TMPro;
using UnityEngine;

public class ClickSpeed : MonoBehaviour {
    int clicks;
    public TMP_Text text;
    float timeDelay = 1;
    void Update () {

        if (Time.time - timeDelay >= 1) {
            timeDelay = Time.time + 1;
            text.text = $"Clicks/s:{clicks}";
            clicks = 0;
        } else {
            if (Input.GetMouseButtonDown (0)) {
                clicks++;
            }
        }

    }
}