using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
// Add this using statement for TextMeshPro
using TMPro;

public class authManager : MonoBehaviour
{
    // Change Text to TextMeshProUGUI
    public TextMeshProUGUI logTxt;

    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    public async void SignIn()
    {
        await signInAnonymous();
    }

    async Task signInAnonymous()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

            print("Sign in Success");
            print("Player Id:" + AuthenticationService.Instance.PlayerId);
            // Use text property for TextMeshPro
            logTxt.text = "Player id:" + AuthenticationService.Instance.PlayerId;
        }
        catch (AuthenticationException ex)
        {
            print("Sign in failed!!");
            Debug.LogException(ex);
        }
    }
}

