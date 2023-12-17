using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public MapRevealManager mapRevealManager;

    // Attach this method to the button click event in the Unity Editor
    public void OnButtonClick()
    {
        // Retrieve the completed levels value from PlayerPrefs
        int completedLevels = PlayerPrefs.GetInt("CompletedLevels");
        Debug.Log("InButtonClick - Completed Levels: " + completedLevels);

        // Call the ActivateMapImages method with the correct value
        mapRevealManager.ActivateMapImages(completedLevels);
    }
    
}