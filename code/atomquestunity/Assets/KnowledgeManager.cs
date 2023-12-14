using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeManager : MonoBehaviour
{
    public int maxKnowledge = 100;
    public int currentKnowledge = 0;

    public Brainbar brainbar;

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
        Debug.Log("Knowledge Manager Initialized. Current Knowledge: " + currentKnowledge);
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
