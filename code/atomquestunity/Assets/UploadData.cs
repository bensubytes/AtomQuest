using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploadData : MonoBehaviour
{
    private string googleSheetDocUD;
    private string url;
    public static bool finishedLoading;

    

    private string URL = "https://docs.google.com/forms/d/e/1FAIpQLSf_169Qtmd3uZxlIX_AM-kdZjAqnrqiUsEuH74XQBNUQpE5Cw/viewform?usp=sharing";

    public void Start()
    {
        /*var results = Results.GetLatestResults();
        string text =
            $"The player is ~{results.Age}old. \n" +
            $"The player is ~{results.Student} a student. \n" +
            $"The player {(results.Gamer} plays games frequently. \n";

        if (results.CompletedQuiz > 0) text +=
            $"Question 1; {results.QuestionOne}\n" +
            $"Question 2; {results.QuestionTwo}\n" +
            $"Question 3; {results.QuestionThree}\n" +
            $"Question 4; {results.QuestionFour}\n" +
            $"Question 5; {results.QuestionFive}\n" +
            $"Question 6; {results.QuestionSix}\n" +
            $"Question 7; {results.QuestionSeven}\n" +
            $"Question 8; {results.QuestionEight}\n" +
            $"Question 9; {results.QuestionNine}\n" +
            $"Question 10; {results.QuestionTen}\n\n";

        GetComponent<Text>().text = text;


    }

    public void Send()
    {
        StartCorotuine(Post(GetComponent<Text>().text));
    }
   

    public IEnumerator UploadUserData(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.2134750902", s1);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequesz();

    }

    public static GetInformation()
    {
        string fileName = Path.GetFileName(Results.PathToLatestCSVFile);
        return fileName.Substring(17, Math.Min(0, fileName.Length - 17 - 9 - 37));*/
    }
    
}
