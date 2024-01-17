using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    private PlayerInput playerInput;

    void Start()
    {
        // Get references to other player scripts or components
        playerInput = GetComponent<PlayerInput>();
    }

    public void DisablePlayerInput()
    {
        // Disable player input or interaction
        playerInput.enabled = false;
        // Add any other components or scripts you want to disable
    }

    public void EnablePlayerInput()
    {
        // Enable player input or interaction
        playerInput.enabled = true;
        // Add any other components or scripts you want to enable
    }
}
