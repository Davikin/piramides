using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler{
    public GameObject correspondingItem;
    private GameObject draggedItem = null;

    public GameObject item {
        get {
            if (transform.childCount > 0)
                return transform.GetChild(0).gameObject;
            return null;
        }
    }

    private Image myImage;
    private bool isLastSibling {
        get {
            if (transform.GetSiblingIndex() == transform.parent.childCount - 1)
                return true;
            else
                return false;
        }
    }

    void Start() {
        if (name.Contains("Slot")) {
            myImage = GetComponent<Image>();
            myImage.color = new Color(1,1,1,0);
        }
    }

    void Update() {
        if (DragHandler.itemBeingDragged) {
            draggedItem = DragHandler.itemBeingDragged;
            print("Item being dragged is: " + draggedItem.name);
        }

        if(draggedItem == correspondingItem && !isLastSibling) {
            transform.SetAsLastSibling();
            print(name +" set as top slot");
        }
    }

    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData) {
        if (!item) {
            if (DragHandler.itemBeingDragged == correspondingItem) {
                print("In proper slot!");
                //DragHandler.itemBeingDragged.transform.SetParent(transform);
                //Destroy(DragHandler.itemBeingDragged.GetComponent<DragHandler>()); //La pieza queda estatica en su slot
                myImage.color = Color.white;
                Destroy(DragHandler.itemBeingDragged);
                Destroy(GetComponent<Slot>());
            }
        }
    }
    #endregion
}


