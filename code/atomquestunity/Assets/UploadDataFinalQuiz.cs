using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UploadDataFinalQuiz : MonoBehaviour
{
    private string googleSheetDocUD;
    private string url;
    public int correctCount = 0;
    public AudioClip toggleSoundEffect;
    private AudioSource audioSource;
    private bool[] questionsAnswered;
    
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
    public Slider progressBar;
    
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

        audioSource = GetComponent<AudioSource>();
        submitButton.onClick.AddListener(Submit);
        questionsAnswered = new bool[entryIDs.Length];

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

        if (selectedOption == -1 && questionsAnswered[index])
        {
            // If the question was previously answered, update the progress bar
            progressBar.value -= 1;
            questionsAnswered[index] = false;
        }
        else if (selectedOption != -1 && !questionsAnswered[index])
        {
            // If the question was not previously answered, update the progress bar
            progressBar.value += 1;
            questionsAnswered[index] = true;
            PlayToggleSoundEffect();
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
        correctCount = 0;

        for (int i = 0; i < toggleValues.Length; i++)
        {
            if (toggleValues[i] == -1)
            {
                allTogglesChanged = false;
                break;
            }

            string selectedOption = googleFormOptions[toggleValues[i]];
            string correctAnswer = GetCorrectAnswerForQuestion(i);

          
            bool isCorrect = (selectedOption == correctAnswer);

            StartCoroutine(UploadUserData(entryIDs[i], isCorrect));

        
            if (isCorrect)
            {
                correctCount++;
            }
        }

        if (allTogglesChanged)
        {
            submitButton.interactable = false;

           
            PlayerPrefs.SetInt("CorrectCountQuiz2", correctCount);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Please select one option for each question before submitting.");
        }
    }

    

    IEnumerator UploadUserData(string entryID, bool isCorrect)
    {
       
        string value = isCorrect ? "True" : "False";

        WWWForm form = new WWWForm();
        form.AddField(entryID, value);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
    
    string GetCorrectAnswerForQuestion(int questionIndex)
    {
        
        string[] correctAnswers = { "False", "True", "True", "False", "True", "True", "False", "True", "True", "False" };
        return correctAnswers[questionIndex];
    }
    
    void PlayToggleSoundEffect()
    {
        if (toggleSoundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(toggleSoundEffect);
        }
    }

}