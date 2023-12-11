using System;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyboardInputManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField; 
    [SerializeField] private TMP_Text resultText; 
    [SerializeField] private string correctText;

    public void ValidateInput()
    {
        string input = inputField.text.Trim();
        if (string.Equals(input, correctText, StringComparison.OrdinalIgnoreCase))
        {
            resultText.text = "True";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "False";
            resultText.color = Color.red;
        }
    }

}