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
    
    private KnowledgeManager knowledgeManager;

    private void Start()
    {
        // Find the KnowledgeManager script in the scene
        knowledgeManager = FindObjectOfType<KnowledgeManager>();
    }

    public void ValidateInput()
    {
        string input = inputField.text.Trim();
        if (string.Equals(input, correctText, StringComparison.OrdinalIgnoreCase))
        {
            resultText.text = "True";
            resultText.color = Color.green;
            knowledgeManager.ObjectDroppedCorrectly();
        }
        else
        {
            resultText.text = "False";
            resultText.color = Color.red;
        }
    }

}