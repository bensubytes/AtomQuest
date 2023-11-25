using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{   
    public int itemID;
    public int requiredItemID;
    public Transform goToPoint;
    public GameObject[] itemsToRemove;
    public string objectName;
    public Vector2 nameTagSize = new Vector2(3, 0.65f);

    [TextArea(3,3)]
    public string hintText;
    public Vector2 hintTagSize = new Vector2(4, 0.65f);
}
