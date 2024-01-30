using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefinitionButtons : MonoBehaviour
{
    public string buttonName;
    private bool isGreyedOut = false;

 
    public bool IsGreyedOut()
    {
        return isGreyedOut;
    }

   
    public void DisableButton()
    {
        isGreyedOut = true;
        
        GetComponent<Image>().color = Color.gray;
        //GetComponent<Button>().interactable = false;
    }
    
    public bool IsMouseOver(Vector2 position)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, position);
    }
}
