using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeManager : MonoBehaviour
{
    public int maxKnowledge = 100;
    public int currentKnowledge = 0;
    public int knowledgePointsPerLevel = 9;

    public Brainbar brainbar;
    private MapRevealManager mapRevealManager;

    void Start()
    {
        LoadKnowledge();
        brainbar.SetMaxBrain(maxKnowledge);
        brainbar.SetBrain(currentKnowledge);

    }

    void AdjustKnowledge(int points)
    {
        currentKnowledge += points;
        currentKnowledge = Mathf.Clamp(currentKnowledge, 0, maxKnowledge);
        brainbar.SetBrain(currentKnowledge);

        CheckLevelCompletion();

        Debug.Log("Knowledge Manager Initialized. Current Knowledge: " + currentKnowledge);
    }

    void CheckLevelCompletion()
    {
        int completedLevels = Mathf.Max(0, currentKnowledge / knowledgePointsPerLevel);
        Debug.Log("Current Knowledge: " + currentKnowledge);
        Debug.Log("Completed Levels (PlayerPrefs) Km: " + completedLevels);

        PlayerPrefs.SetInt("CompletedLevels", completedLevels);
        PlayerPrefs.Save();

        Debug.Log("Completed Levels (PlayerPrefs) Saved: " + completedLevels);
    }

    public bool HasEnoughKnowledge(float requiredKnowledge)
    {
        return currentKnowledge >= requiredKnowledge;
    }


    public void ObjectDroppedCorrectly()
    {
        AdjustKnowledge(3);
        Debug.Log("Adjusting");
        Debug.Log(currentKnowledge);
    }

    private void SaveKnowledge()
    {
        PlayerPrefs.SetInt("KnowledgePoints", currentKnowledge);
        PlayerPrefs.Save();
    }

    private void LoadKnowledge()
    {
        currentKnowledge = PlayerPrefs.GetInt("KnowledgePoints", 0);
    }
}
