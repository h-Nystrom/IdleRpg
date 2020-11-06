using UnityEngine;

namespace Common {
    public class FloatingText : MonoBehaviour {
        public Vector3 moveDirection = Vector3.up * 20f;
        public float variation = 5f;
        public float alphaFadeSpeed = 5f;

        void Start () {
            this.variation = Random.Range (-this.variation, this.variation);
            this.transform.position += new Vector3 (Random.Range (-this.variation, this.variation), 0f, 0f);
            this.moveDirection.x += this.variation;
        }

        void Update () {
            this.transform.position += this.moveDirection * Time.deltaTime;
            var text = GetComponent<TMPro.TMP_Text> ();
            var color = text.color;
            color.a -= this.alphaFadeSpeed * Time.deltaTime;
            text.color = color;
            if (color.a <= 0f) {
                Destroy (this.gameObject);
            }
        }
    }
}