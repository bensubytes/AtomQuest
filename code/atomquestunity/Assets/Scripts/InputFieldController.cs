using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    public TMP_InputField inputField;

    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}