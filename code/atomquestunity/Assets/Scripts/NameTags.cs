using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTags : MonoBehaviour
{
    Vector2 resolution;
    Vector2 resolutionInWorldUnits = new Vector2(17.8f, 10);

    void Start()
    {
        resolution = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        //convert position from pixels to world space

        transform.position = Input.mousePosition/resolution * resolutionInWorldUnits;
    }
}
