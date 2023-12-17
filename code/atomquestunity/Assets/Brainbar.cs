using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Brainbar : MonoBehaviour
{
    public Slider slider;
    public float animationDuration = 0.5f;

    private int currentKnowledge = 0;

    private static Brainbar instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetMaxBrain(100);
        LoadKnowledge();
        SetBrain(currentKnowledge);
    }

    public void SetMaxBrain(int knowledge)
    {
        slider.maxValue = knowledge;
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