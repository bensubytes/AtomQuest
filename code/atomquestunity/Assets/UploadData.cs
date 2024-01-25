using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UploadData : MonoBehaviour
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
    public ToggleGroup toggleGroup11;

    public TMP_InputField ageInput;
    public TMP_InputField majorInput;

    public int[] toggleValues;

    public Button submitButton;
    public Slider progressBar;

    private string URL =
        "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf_169Qtmd3uZxlIX_AM-kdZjAqnrqiUsEuH74XQBNUQpE5Cw/formResponse";

    private string[] googleFormOptions = { "False", "True" };
    private string[] googleFormOptionsQ11 = { "No", "Sometimes", "Often" };

    private string[] entryIDs =
    {
        "entry.2122923367",
        "entry.1449255233",
        "entry.2513360",
        "entry.130381684",
        "entry.643161201",
        "entry.896110038",
        "entry.140061374",
        "entry.678762217",
        "entry.945203479",
        "entry.779661951",
        "entry.847834694", //q11
        "entry.1522402797", //age
        "entry.1060265220", //major
        
    };

    void Start()
    {
        toggleValues = new int[entryIDs.Length];
        submitButton.onClick.AddListener(Submit);
        audioSource = GetComponent<AudioSource>();
        questionsAnswered = new bool[entryIDs.Length];
    }

    
    public void OnInputValueChanged(TMP_InputField inputField)
    {
        progressBar.value++;
        PlayToggleSoundEffect();
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
            case 10:
                return toggleGroup11.GetComponentsInChildren<Toggle>();


            default:
                return null;
        }
    }
    // ... (existing code)

    void Submit()
    {
        bool allTogglesChanged = true;
        correctCount = 0; // Reset correct count before checking the answers

        for (int i = 0; i < toggleValues.Length - 2; i++)
        {
            if (toggleValues[i] == -1)
            {
                allTogglesChanged = false;
                break;
            }
        }

        if (allTogglesChanged)
        {
            StartCoroutine(UploadUserData1(entryIDs[11], ageInput.text));
            StartCoroutine(UploadUserData1(entryIDs[12], majorInput.text));

            for (int i = 0; i < toggleValues.Length - 2; i++)
            {
                if (i == 10)
                {
                    string optionForQ11 = (toggleValues[i] == 2) ? "Often" : googleFormOptionsQ11[toggleValues[i]];
                    StartCoroutine(UploadUserData1(entryIDs[i], optionForQ11));
                }
                else
                {
                    string selectedOption = googleFormOptions[toggleValues[i]];
                    string correctAnswer = GetCorrectAnswerForQuestion(i);
                    bool isCorrect = (selectedOption == correctAnswer);
                    StartCoroutine(UploadUserData(entryIDs[i], isCorrect));

                    if (isCorrect)
                    {
                        correctCount++;
                    }
                }

                PlayerPrefs.SetInt("CorrectCountQuiz1", correctCount);
                PlayerPrefs.Save();
                Debug.Log(correctCount);
            }
        }
    }


    IEnumerator UploadUserData1(string entryID, string value)
    { 
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
        // Replace this with the actual correct answers for each question
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