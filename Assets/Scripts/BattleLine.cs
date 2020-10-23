using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleLine : MonoBehaviour, IDropHandler {
    public void OnDrop (PointerEventData eventData) {
        Debug.Log ("Drop");
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<DragableUI> ().endOfDragUI = this.transform;
            eventData.pointerDrag.GetComponent<RectTransform> ().position = GetComponent<RectTransform> ().position;
        }
    }
}