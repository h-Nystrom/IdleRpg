using UnityEngine;

public class DestroyGameObjectAfterTime : MonoBehaviour {
    public float destroyDelay;
    void Start () {
        Destroy (this.gameObject, destroyDelay);
    }
}