using UnityEngine;
using UnityEngine.UI;

public class MapRevealManager : MonoBehaviour
{
    public Image[] mapImages; // Array of images representing different stages of the map

    // Remove the Update method

    private void LoadLevels()
    {
        // Check if PlayerPrefs data exists for completed levels
        if (PlayerPrefs.HasKey("CompletedLevels"))
        {
            int completedLevels = PlayerPrefs.GetInt("CompletedLevels");
        }
    }

    public void ActivateMapImages(int completedLevelsX)
    {
        LoadLevels();
        completedLevelsX = PlayerPrefs.GetInt("CompletedLevels");
        Debug.Log("ActivateMapImages - Called with Completed Levels: " + completedLevelsX);

        // Activate images based on the number of completed levels
        for (int i = 0; i < Mathf.Min(completedLevelsX, mapImages.Length); i++)
        {
            mapImages[i].gameObject.SetActive(true);
        }
    }

    public void DeactivateMapImages(int completedLevelsX)
    {
        for (int i = 0; i < Mathf.Min(completedLevelsX, mapImages.Length); i++)
        {
            mapImages[i].gameObject.SetActive(false);
        }
    }
}