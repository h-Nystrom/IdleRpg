using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
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
        transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
        canvasGroup.alpha = 0.4f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag (PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnEndDrag (PointerEventData eventData) {
        if (endOfDragUI.tag == "Inventory")
            transform.localScale = Vector3.one;
        if (endOfDragUI.tag == "Tile")
            transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);

        transform.SetParent (endOfDragUI);
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnPointerEnter (PointerEventData eventData) {
        if (eventData.pointerEnter.gameObject.tag == "BattleField") {
            Debug.Log ("BattleField on");
        }
    }

    public void OnPointerExit (PointerEventData eventData) {
        if (eventData.pointerEnter.gameObject.tag == "BattleField") {
            Debug.Log ("BattleField off");
        }
    }
}