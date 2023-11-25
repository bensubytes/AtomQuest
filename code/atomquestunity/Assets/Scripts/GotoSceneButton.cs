using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GotoSceneButton : MonoBehaviour
{
    [SerializeField] private string Scene;
    private void Start()
    {
        SceneManager.LoadScene(Scene);
    }

    
}
