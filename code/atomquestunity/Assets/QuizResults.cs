using UnityEngine;
using TMPro;

public class QuizResults : MonoBehaviour
{

    public TMP_Text scoreTextPre;
    public TMP_Text scoreTextPost;
    public TMP_Text resultText;  // Reference to the Text component to display the results

    void Start()
    {
        CompareResults();
    }

    void CompareResults()
    {
        int correctCount1 = PlayerPrefs.GetInt("CorrectCountQuiz1", 0);
        Debug.Log(PlayerPrefs.GetInt("CorrectCountQuiz1"));
        int correctCount2 = PlayerPrefs.GetInt("CorrectCountQuiz2", 0);
        Debug.Log(PlayerPrefs.GetInt("CorrectCountQuiz2"));

        scoreTextPre.text = correctCount1.ToString();
        scoreTextPost.text = correctCount2.ToString();
        
        if (correctCount1 > correctCount2)
        {
            resultText.text = "Quiz 1 has more correct answers than Quiz 2.";
        }
        else if (correctCount1 < correctCount2)
        {
            resultText.text = "Good job, your knowledge improved!";
        }
        else
        {
            resultText.text = "Both quizzes have the same number of correct answers.";
        }
    }
}