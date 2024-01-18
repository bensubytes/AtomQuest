using UnityEngine;
using TMPro;

public class QuizResults : MonoBehaviour
{

    public TMP_Text resultText;  // Reference to the Text component to display the results

    void Start()
    {
        CompareResults();
    }

    void CompareResults()
    {
        int correctCount1 = PlayerPrefs.GetInt("CorrectCountQuiz1", 0);
        int correctCount2 = PlayerPrefs.GetInt("CorrectCountQuiz2", 0);


        // You can compare the correct counts and display the results
        if (correctCount1 > correctCount2)
        {
            resultText.text = "Quiz 1 has more correct answers than Quiz 2.";
        }
        else if (correctCount1 < correctCount2)
        {
            resultText.text = "Quiz 2 has more correct answers than Quiz 1.";
        }
        else
        {
            resultText.text = "Both quizzes have the same number of correct answers.";
        }
    }
}