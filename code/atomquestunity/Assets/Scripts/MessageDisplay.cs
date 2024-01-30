using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    private TMP_Text messageText;

    private void Start()
    {
        messageText = GetComponent<TMP_Text>();
        messageText.text = "";
    }

    public void DisplayMessage(string message)
    {
       
        messageText.text = message;

        Invoke("ClearMessage", 2f);
    }

    public void ClearMessage()
    {
       
        messageText.text = "";
    }
}