using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmptySlot : MonoBehaviour, IDropHandler
{
    public int id;
    public float snapThreshold = 50f;
    public Brainbar brainbar;
    public int knowledgePoints = 5;

    public KnowledgeManager knowledgeManager;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragDrop>().id == id)
            {
                RectTransform draggedRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
                RectTransform emptySlotRectTransform = GetComponent<RectTransform>();

               
                float distance = Vector2.Distance(draggedRectTransform.anchoredPosition, emptySlotRectTransform.anchoredPosition);

                if (distance <= snapThreshold)
                {
                    draggedRectTransform.anchoredPosition = emptySlotRectTransform.anchoredPosition;
                    knowledgeManager.ObjectDroppedCorrectly();
                   
                }
                else
                {
                    
                    eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
                }
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
            }
        }
    }

}