using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    private PlayerInput playerInput;
    

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void DisablePlayerInput()
    {
        playerInput.enabled = false;
    }

    public void EnablePlayerInput()
    {
        // Enable player input or interaction
        playerInput.enabled = true;
        // Add any other components or scripts you want to enable
    }
}
