using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public MapRevealManager mapRevealManager;
    
    public void OnButtonClick()
    {
        int completedLevels = PlayerPrefs.GetInt("CompletedLevels");
        Debug.Log("InButtonClick - Completed Levels: " + completedLevels);
        
        mapRevealManager.ActivateMapImages(completedLevels);
    }
    
}