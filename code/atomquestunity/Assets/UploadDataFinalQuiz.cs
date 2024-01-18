using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
public class UploadDataFinalQuiz : MonoBehaviour
{
    private string googleSheetDocUD;
    private string url;
    public int correctCount = 0;
    private bool isCorrect;

    public ToggleGroup toggleGroup1;
    public ToggleGroup toggleGroup2;
    public ToggleGroup toggleGroup3;
    public ToggleGroup toggleGroup4;
    public ToggleGroup toggleGroup5;
    public ToggleGroup toggleGroup6;
    public ToggleGroup toggleGroup7;
    public ToggleGroup toggleGroup8;
    public ToggleGroup toggleGroup9;
    public ToggleGroup toggleGroup10;

    public int[] toggleValues;

    public Button submitButton;

    private string URL =
        "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeph014CNb0GK2dNYravbzqiSQxjIQKZChbKsD0G0U5q8IwOQ/formResponse";

    private string[] googleFormOptions = { "False", "True" };

    private string[] entryIDs =
    {
        "entry.2076876060",
        "entry.992569325",
        "entry.1319909424",
        "entry.580857628",
        "entry.1937036566",
        "entry.852606929",
        "entry.763047478",
        "entry.785923666",
        "entry.928727109",
        "entry.45900614",
    };

    void Start()
    {
        toggleValues = new int[entryIDs.Length];


        submitButton.onClick.AddListener(Submit);

    }


    public void OnToggleValueChanged(int index)
    {
        Toggle[] toggles = GetToggles(index);
        int selectedOption = -1;

        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                selectedOption = i;
                toggleValues[index] = selectedOption;
            }
        }

        if (selectedOption == -1)
        {

            toggleValues[index] = -1;
        }
    }


    Toggle[] GetToggles(int index)
    {
        switch (index)
        {
            case 0:
                return toggleGroup1.GetComponentsInChildren<Toggle>();
            case 1:
                return toggleGroup2.GetComponentsInChildren<Toggle>();
            case 2:
                return toggleGroup3.GetComponentsInChildren<Toggle>();
            case 3:
                return toggleGroup4.GetComponentsInChildren<Toggle>();
            case 4:
                return toggleGroup5.GetComponentsInChildren<Toggle>();
            case 5:
                return toggleGroup6.GetComponentsInChildren<Toggle>();
            case 6:
                return toggleGroup7.GetComponentsInChildren<Toggle>();
            case 7:
                return toggleGroup8.GetComponentsInChildren<Toggle>();
            case 8:
                return toggleGroup9.GetComponentsInChildren<Toggle>();
            case 9:
                return toggleGroup10.GetComponentsInChildren<Toggle>();



            default:
                return null;
        }
    }
    void Submit()
    {
        bool allTogglesChanged = true;
        for (int i = 0; i < toggleValues.Length; i++)
        {
            if (toggleValues[i] == -1)
            {
                allTogglesChanged = false;
                break;
            }
        }

        if (allTogglesChanged)
        {
            for (int i = 0; i < toggleValues.Length; i++)
            {
                bool isCorrect = (googleFormOptions[toggleValues[i]] == GetCorrectAnswerForQuestion(i));
                StartCoroutine(UploadUserData(entryIDs[i], googleFormOptions[toggleValues[i]]));
            }
            submitButton.interactable = false;
        }
        else
        {
            Debug.Log("Please select one option for each question before submitting.");
        }
        
        PlayerPrefs.SetInt("CorrectCountQuiz2", correctCount);
        PlayerPrefs.Save();
    }

    IEnumerator UploadUserData(string entryID, string value)
    {
        WWWForm form = new WWWForm();
        form.AddField(entryID, value);

        using UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
            if (isCorrect)
            {
                correctCount++;
            }

        }
    }
    
    string GetCorrectAnswerForQuestion(int questionIndex)
    {
        // Replace this with the actual correct answers for each question
        string[] correctAnswers = { "False", "True", "True", "False", "True", "True", "False", "True", "True", "False" };
        return correctAnswers[questionIndex];
    }

}