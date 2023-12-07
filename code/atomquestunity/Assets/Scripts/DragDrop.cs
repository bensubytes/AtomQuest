using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public int id;
    private Vector2 initPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initPos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out Vector2 localPoint);
        rectTransform.anchoredPosition = localPoint;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
       Debug.Log("OnPointerDown");
    }

    public void ResetPosition()
    {
        transform.position = initPos;
    }
    
}
