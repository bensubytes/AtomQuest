using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public int id;
    private Vector2 initPos;
    private bool isDragging = false;
    private bool placedCorrectly = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initPos = transform.position;
        
        GameObject canvasObject = GameObject.FindWithTag("AtomCanvas");

        if (canvasObject != null)
        {
            canvas = canvasObject.GetComponent<Canvas>();
        }
        else
        {
            //Debug.LogError("Canvas with tag 'AtomCanvas' not found in the scene.");
        }
    }

    public void SetPlacedCorrectly(bool value)
    {
        placedCorrectly = value;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        if (!placedCorrectly)
        {
            isDragging = true; 
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out Vector2 localPoint);
        rectTransform.anchoredPosition = localPoint;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }

    public bool IsDragging()
    {
        return isDragging;
    }
    public void ResetPosition()
    {
        transform.position = initPos;
    }
    
}