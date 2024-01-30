using UnityEngine;
using UnityEngine.EventSystems;

public class EmptySlot : MonoBehaviour, IDropHandler
{
    public int id;
    public float snapThreshold = 50f;
    public KnowledgeManager knowledgeManager;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag == null)
            return;

        DragDrop dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();

        if (dragDrop == null)
            return;

        if (dragDrop.id == id)
        {
            RectTransform draggedRectTransform = dragDrop.GetComponent<RectTransform>();
            RectTransform emptySlotRectTransform = GetComponent<RectTransform>();

            float distance = Vector2.Distance(draggedRectTransform.anchoredPosition, emptySlotRectTransform.anchoredPosition);

            if (distance <= snapThreshold)
            {
                draggedRectTransform.anchoredPosition = emptySlotRectTransform.anchoredPosition;
                dragDrop.SetPlacedCorrectly(true);
                knowledgeManager.ObjectDroppedCorrectly();
            }
            else
            {
                dragDrop.ResetPosition();
                knowledgeManager.ObjectDroppedIncorrectly();
            }
        }
        else
        {
            dragDrop.ResetPosition();
            knowledgeManager.ObjectDroppedIncorrectly();
        }
    }
}