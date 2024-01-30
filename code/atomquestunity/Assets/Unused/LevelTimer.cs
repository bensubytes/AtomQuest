using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public float timeLimitInSeconds = 60f;
    public float currentTime;

    public TMP_Text timerText;

    void Start()
    {
        currentTime = timeLimitInSeconds;

        timerText = GameObject.FindWithTag("TimerText").GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            
            RestartLevel();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}