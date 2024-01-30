using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Brainbar : MonoBehaviour
{
    public Slider slider;
    public float animationDuration = 0.5f;

    public int maxKnowledge = 86;
    public int currentKnowledge = 0;
    public int knowledgePointsPerLevel = 9;

    private static Brainbar instance;
    

    void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        if (instance == null && 
            (currentSceneName == "Cutscene2" || currentSceneName == "Post-Quiz" || currentSceneName == "Results"))
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        SetMaxBrain(86);
        LoadKnowledge();
        SetBrain(currentKnowledge);
    }

    public void SetMaxBrain(int knowledge)
    {
        slider.maxValue = maxKnowledge;
        slider.value = knowledge;
    }

    public void SetBrain(int knowledge)
    {
        currentKnowledge = knowledge;
        StartCoroutine(SmoothSliderTransition(knowledge));
    }

    public void AddKnowledgePoints(int points)
    {
        currentKnowledge += points;
        SaveKnowledge(); // Save knowledge points when new points are gained
        SetBrain(currentKnowledge);
    }

    private IEnumerator SmoothSliderTransition(int targetValue)
    {
        float startTime = Time.time;
        float startValue = slider.value;

        while (Time.time < startTime + animationDuration)
        {
            float elapsed = Time.time - startTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);

            slider.value = Mathf.Lerp(startValue, targetValue, t);

            yield return null;
        }

        slider.value = targetValue; // Ensure the final value is set
    }

    private void SaveKnowledge()
    {
        PlayerPrefs.SetInt("KnowledgePoints", currentKnowledge);
        PlayerPrefs.Save();
        Debug.Log("Knowledge saved: " + currentKnowledge);
    }

    public void LoadKnowledge()
    {
        currentKnowledge = PlayerPrefs.GetInt("KnowledgePoints", 0);
        SetBrain(currentKnowledge);
        Debug.Log("Knowledge loaded: " + currentKnowledge);
    }

    public int GetCurrentKnowledge()
    {
        return currentKnowledge;
    }
}