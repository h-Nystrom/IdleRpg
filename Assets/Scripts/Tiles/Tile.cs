using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour, IDropHandler {
    bool _inUse;
    public bool InUse { get => _inUse; set => _inUse = value; }
    public void OnDrop (PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            Debug.Log ("Tile in use");
        }
    }
}