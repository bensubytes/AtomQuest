using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class ContactForm : MonoBehaviour
{
    public TMP_InputField name;
    public TMP_InputField email;
    public TMP_InputField subject;
    public TMP_InputField message;

    private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdUmdQNXg9NZB9RdiTR3YA0j1tNYWUNK707ipsWtLtzinG8UA/formResponse";

    void Start()
    {
        /*string text =
        $"Name:{}\n" +
        $"Email: {}\n\n" +
        $"Subject: {}\n" +
        $"Message: {}\n";*/


       // GetComponent<Text>().text = text;
    }
    

    public void Send()
    {
        StartCoroutine(Post(GetComponent<Text>().text));
    }

    IEnumerator Post(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.995141875", s1);

        using UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();
        


    }
    
}
