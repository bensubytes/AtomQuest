using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmptySlot : MonoBehaviour, IDropHandler
{
    public int id;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragDrop>().id == id)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                this.GetComponent<RectTransform>().anchoredPosition;
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
            }
        }
    }
}
