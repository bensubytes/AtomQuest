using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class KeyboardInputManager : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> inputFields; 
    [SerializeField] private TMP_Text resultText; 
    [SerializeField] private List<string> correctTexts;

    private KnowledgeManager knowledgeManager;

    private void Start()
    {
        knowledgeManager = FindObjectOfType<KnowledgeManager>();
    }
    
    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
    }

    public void ValidateInput()
    {
        
        bool allCorrect = true;

        for (int i = 0; i < inputFields.Count; i++)
        {
            string input = inputFields[i].text.Trim();
            string correctText = correctTexts[i];

            if (!string.Equals(input, correctText, StringComparison.OrdinalIgnoreCase))
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            resultText.text = "True";
            resultText.color = Color.green;
            knowledgeManager.ObjectDroppedCorrectly();
            knowledgeManager.FeedbackAudio(knowledgeManager.rightClip);
        }
        else
        {
            resultText.text = "False";
            knowledgeManager.ObjectDroppedIncorrectly();
            knowledgeManager.FeedbackAudio(knowledgeManager.wrongClip);
            resultText.color = Color.red;
        }
    }
}