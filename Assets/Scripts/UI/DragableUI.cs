using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    public Transform dragingUI;
    public Transform endOfDragUI;
    CanvasGroup canvasGroup;
    RectTransform rect;
    void Awake () {
        canvasGroup = GetComponent<CanvasGroup> ();
        rect = GetComponent<RectTransform> ();
    }
    public void OnBeginDrag (PointerEventData eventData) {
        transform.SetParent (dragingUI);
        transform.localScale = Vector3.one;
        canvasGroup.alpha = 0.4f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag (PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnEndDrag (PointerEventData eventData) {
        if (endOfDragUI.tag == "Tile") {
            transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
            transform.SetParent (endOfDragUI);
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            this.enabled = false;
        } else {
            Destroy (gameObject);
        }

    }
}