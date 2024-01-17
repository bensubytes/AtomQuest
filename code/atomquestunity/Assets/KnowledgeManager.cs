// KnowledgeManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeManager : MonoBehaviour
{
    public int maxKnowledge = 100;
    private Brainbar brainbar;
    public bool deductPointsEnabled = true;
    public MessageDisplay messageDisplay;
    public string wrongPlacementMessage = "-1 Knowledge";
    
    void Start()
    {
        // Find the Brainbar component in the scene
        brainbar = GameObject.FindObjectOfType<Brainbar>();

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
        Debug.Log("Adjusting");
        Debug.Log(GetCurrentKnowledge());
    }

    public void ObjectDroppedIncorrectly()
    {
        if (deductPointsEnabled)
        {
            AdjustKnowledge(-1);
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

    private void SetCurrentKnowledge(int knowledge)
    {
        PlayerPrefs.SetInt("KnowledgePoints", knowledge);
        PlayerPrefs.Save();
    }

    private int GetCurrentKnowledge()
    {
        return PlayerPrefs.GetInt("KnowledgePoints", 0);
    }
}
