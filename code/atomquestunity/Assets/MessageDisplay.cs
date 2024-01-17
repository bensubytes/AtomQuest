using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    private TMP_Text messageText;

    private void Start()
    {
        messageText = GetComponent<TMP_Text>();
        // Set an initial message or leave it empty
        messageText.text = "";
    }

    public void DisplayMessage(string message)
    {
        // Display the provided message in the UI Text
        messageText.text = message;

        Invoke("ClearMessage", 2f);
    }

    public void ClearMessage()
    {
        // Clear the message in the UI Text
        messageText.text = "";
    }
}