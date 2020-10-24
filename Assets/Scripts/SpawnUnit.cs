using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnUnit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    public GameObject unitPrefab;
    public Transform parent;

    public DraggingUnit draggingUnit;
    //New unit:
    GameObject newUnit;

    void Start () {
        draggingUnit = FindObjectOfType<DraggingUnit> ();
    }
    public void OnBeginDrag (PointerEventData eventData) {
        newUnit = Instantiate (unitPrefab, parent);
        draggingUnit.IsDraggingUnit (true);
    }

    public void OnDrag (PointerEventData eventData) {
        newUnit.transform.position = eventData.position;
    }

    public void OnEndDrag (PointerEventData eventData) {
        if (eventData.pointerEnter.transform.tag == "Tile" && !eventData.pointerEnter.GetComponent<Tile> ().InUse) {
            //Call the buying method here!
            newUnit.GetComponent<Unit> ().SetupUnit (eventData.pointerEnter.transform);
        } else {
            Destroy (newUnit);
        }
        draggingUnit.IsDraggingUnit (false);
    }
}