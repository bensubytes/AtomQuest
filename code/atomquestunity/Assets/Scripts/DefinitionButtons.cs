using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefinitionButtons : MonoBehaviour
{
    public string buttonName; // You might want to identify buttons by name
    private bool isGreyedOut = false;

    // Check if the button is part of a correct pair
    public bool IsCorrectPair(Button otherButton)
    {
        // Implement your logic for checking correct pairs
        // For example, compare the names or IDs of the buttons
        return buttonName == otherButton.buttonName;
    }

    // Check if the button is already greyed out
    public bool IsGreyedOut()
    {
        return isGreyedOut;
    }

    // Disable the button (grey it out)
    public void DisableButton()
    {
        isGreyedOut = true;

        // You might want to change the visual appearance of the button
        // For example, change the color or disable interaction
        GetComponent<Image>().color = Color.gray;
        //GetComponent<Button>().interactable = false;
    }

    // Check if the mouse is over the button
    public bool IsMouseOver(Vector2 position)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, position);
    }
}
