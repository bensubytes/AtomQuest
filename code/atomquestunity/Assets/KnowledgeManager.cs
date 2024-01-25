// KnowledgeManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeManager : MonoBehaviour
{
    public int maxKnowledge = 70;
    private int initialKnowledge;
    private Brainbar brainbar;
    public bool deductPointsEnabled = true;
    public MessageDisplay messageDisplay;
    public string wrongPlacementMessage = "-1 Knowledge";
    public AudioClip wrongClip;
    public AudioClip rightClip;
    private AudioSource audioSource;
    
    void Start()
    {
   
        brainbar = GameObject.FindObjectOfType<Brainbar>();
        initialKnowledge = GetCurrentKnowledge();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.3f;
        if (brainbar == null)
        {
            Debug.LogError("Brainbar not found in the scene!");
        }
        else
        {
            LoadKnowledge();
            brainbar.SetMaxBrain(maxKnowledge);
            brainbar.SetBrain(GetCurrentKnowledge());
        }
    }

    public void AdjustKnowledge(int points)
    {
        int newKnowledge = GetCurrentKnowledge() + points;
        newKnowledge = Mathf.Clamp(newKnowledge, 0, maxKnowledge);
        SaveKnowledge(newKnowledge);
        brainbar.SetBrain(newKnowledge);
        CheckLevelCompletion();
    }

    void CheckLevelCompletion()
    {
        int completedLevels = Mathf.Max(0, GetCurrentKnowledge() / brainbar.knowledgePointsPerLevel);
        Debug.Log("Current Knowledge: " + GetCurrentKnowledge());
        Debug.Log("Completed Levels (PlayerPrefs): " + completedLevels);

        PlayerPrefs.SetInt("CompletedLevels", completedLevels);
        PlayerPrefs.Save();

        Debug.Log("Completed Levels (PlayerPrefs) Saved: " + completedLevels);
    }

    public bool HasEnoughKnowledge(float requiredKnowledge)
    {
        return GetCurrentKnowledge() >= requiredKnowledge;
    }

    public void SetDeductPointsEnabled(bool enable)
    {
        deductPointsEnabled = enable;
    }
    public void ObjectDroppedCorrectly()
    {
        AdjustKnowledge(3);
        FeedbackAudio(rightClip);
        Debug.Log("Adjusting");
        Debug.Log(GetCurrentKnowledge());
    }

    public void ObjectDroppedIncorrectly()
    {
        if (deductPointsEnabled)
        {
            AdjustKnowledge(-1);
            FeedbackAudio(wrongClip);
            messageDisplay.DisplayMessage(wrongPlacementMessage);
            Debug.Log("Deductingpoints");
        }
        
    }

    private void SaveKnowledge(int knowledge)
    {
        PlayerPrefs.SetInt("KnowledgePoints", knowledge);
        PlayerPrefs.Save();
    }

    private void LoadKnowledge()
    {
        int loadedKnowledge = PlayerPrefs.GetInt("KnowledgePoints", 0);
        SetCurrentKnowledge(loadedKnowledge);
    }

    public void SetCurrentKnowledge(int knowledge)
    {
        PlayerPrefs.SetInt("KnowledgePoints", knowledge);
        PlayerPrefs.Save();
    }

    public void ResetKnowledge()
    {
        int currentKnowledge = GetCurrentKnowledge();
        int knowledgeCollectedInLevel = currentKnowledge - initialKnowledge;

        
        currentKnowledge -= knowledgeCollectedInLevel;
        
        currentKnowledge = Mathf.Max(currentKnowledge, 0);

        SetCurrentKnowledge(currentKnowledge);
    }
    
    private int GetCurrentKnowledge()
    {
        return PlayerPrefs.GetInt("KnowledgePoints", 0);
    }

    public void FeedbackAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    
}
