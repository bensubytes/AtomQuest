using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level1");
    }
}