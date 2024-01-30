using UnityEngine;
using TMPro;

public class QuizResults : MonoBehaviour
{
    public TMP_Text scoreTextPre;
    public TMP_Text scoreTextPost;
    public TMP_Text resultText;
    public TMP_Text fullPointsText;

    private void Start()
    {
        CompareResults();
    }

    private void CompareResults()
    {
        int correctCountQuiz1 = PlayerPrefs.GetInt("CorrectCountQuiz1", 0);
        int correctCountQuiz2 = PlayerPrefs.GetInt("CorrectCountQuiz2", 0);
        int knowledgePoints = PlayerPrefs.GetInt("KnowledgePoints", 0);
        

        scoreTextPre.text = correctCountQuiz1.ToString();
        scoreTextPost.text = correctCountQuiz2.ToString();

        if (correctCountQuiz1 > correctCountQuiz2)
        {
            resultText.text = "Quiz 1 has more correct answers than Quiz 2.";
        }
        else if (correctCountQuiz1 < correctCountQuiz2)
        {
            resultText.text = "Good job, your knowledge improved!";
        }
        else
        {
            resultText.text = "Both quizzes have the same number of correct answers.";
        }

        if (knowledgePoints >= 87)
        {
            fullPointsText.text = "Brainpower maxed out! Congratulations!";
        }
    }
}