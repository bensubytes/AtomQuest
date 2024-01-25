using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardInputManagerDoor : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private string correctText;
    [SerializeField] private string sceneToLoad; // Add a variable to store the scene to load

    private KnowledgeManager knowledgeManager;

    private void Start()
    {
        // Find the KnowledgeManager script in the scene
        knowledgeManager = FindObjectOfType<KnowledgeManager>();
    }

    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
    }
    public void ValidateInput()
    {
        string input = inputField.text.Trim();
        if (IsInputCorrect(input))
        {
            resultText.text = "True";
            resultText.color = Color.green;

            // Load the scene if the result is true
            LoadScene();
            
            // Alternatively, you can uncomment the following line if you still want to call ObjectDroppedCorrectly
            // knowledgeManager.ObjectDroppedCorrectly();
        }
        else
        {
            resultText.text = "False";
            resultText.color = Color.red;
        }
    }

    public bool IsInputCorrect(string input)
    {
        return string.Equals(input, correctText, StringComparison.OrdinalIgnoreCase);
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene to load is not specified in the KeyboardInputManager.");
        }
    }
}