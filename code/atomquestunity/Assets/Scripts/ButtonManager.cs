using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons;

    void Start()
    {
        GameObject[] buttonObjects = GameObject.FindGameObjectsWithTag("DefinitionButtons");

        buttons = new Button[buttonObjects.Length];
        for (int i = 0; i < buttonObjects.Length; i++)
        {
            Debug.Log("Processing game object: " + buttonObjects[i].name);
            buttons[i] = buttonObjects[i].GetComponent<Button>();

            if (buttons[i] == null)
            {
                Debug.LogError("Button component not found on game object: " + buttonObjects[i].name);
            }
        }
    }


    // Method to get the button at a given position
    /* public Button GetButtonAtPosition(Vector2 position)
     {
         foreach (Button button in buttons)
         {
             if (button.IsMouseOver(position))
             {
                 return button;
             }
         }

         return null;
     }*/
}