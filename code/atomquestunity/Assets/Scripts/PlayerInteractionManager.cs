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
       
        playerInput.enabled = true;
       
    }
}
