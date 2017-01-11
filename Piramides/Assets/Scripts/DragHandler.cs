using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public static GameObject itemBeingDragged;
    Vector3 startPos;
    Transform startParent, dragParent;
    public bool inProperSlot = false;
    public bool firstDrag = true;

    #region IBeginDragHandler implementation
    public void OnBeginDrag(PointerEventData eventData) {
        itemBeingDragged = gameObject;
        startPos = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        if (transform.parent != dragParent) transform.SetParent(transform.parent.parent.parent.parent);
        if (firstDrag) {
            dragParent = transform.parent;
            firstDrag = false;
        }
    }
    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }
    #endregion

    #region IEndDragHandler implementation
    public void OnEndDrag(PointerEventData eventData) {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (!inProperSlot) {
            transform.SetParent(startParent);
            transform.position = startPos;
        }
        
    }
    #endregion
}
