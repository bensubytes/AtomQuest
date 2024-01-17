using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FeedbackForm : MonoBehaviour
{
    [SerializeField] private TMP_InputField feedback;

    private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdUmdQNXg9NZB9RdiTR3YA0j1tNYWUNK707ipsWtLtzinG8UA/formResponse";

    public void Send()
    {
        StartCoroutine(Post(feedback.text));
    }

    IEnumerator Post(string sfeedback)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.995141875", sfeedback);
        
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }
}
