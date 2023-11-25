using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererManager : MonoBehaviour
{
    private LineRenderer lineRend;
    private Vector2 mousePosition;
    private Vector2 startMousePosition;



    private float distance;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector3(startMousePosition.x, startMousePosition.y, 0f));
            lineRend.SetPosition(1, new Vector3(mousePosition.x, mousePosition.y, 0f));
            distance = (mousePosition - startMousePosition).magnitude;
        }
    }
}
