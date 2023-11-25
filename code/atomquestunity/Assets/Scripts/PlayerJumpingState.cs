using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    [Header("Jump")] 
    public float jumppower = 5f;
    
    private float startIdleTimer = 0.1f;
    private float idleTimer = 0.1f;
    
    public void EnterState(Playermovement player, float modifier)
    {
        player.rb.velocity = new Vector2(Mathf.Clamp(player.rb.velocity.x, -player.maxspeed, player.maxspeed), 0);
        player.rb.AddForce(new Vector2(0, modifier*jumppower), ForceMode2D.Impulse);
        //player.SoundManager.JumpingSound.Play();
    }
    
    public void Update(Playermovement player)
    {
        //if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (player.Actionsleft > 0))
        if (Input.GetButtonDown("Jump"))
        {
           
            Jump(player);
            //player.SoundManager.JumpingSound.Play();
        }
        
    }
    
    public void CheckIfIdle(Playermovement player)
    {
        if (player.grounded && player.rb.velocity.y < 0.1)
        {
            //if (idleTimer <= 0)
            {
                player.TransitionToState(player.IdleState,0);
                player.PreviousState = player.IdleState;
                idleTimer = startIdleTimer;
            }
            //else
            {
                idleTimer -= Time.deltaTime;
            }
        }
    }

    public void Walk(Playermovement player)
    {
        if (Mathf.Abs(player.rb.velocity.x) < 1f)
        {
            player.animator.SetBool("walking", false);
        }
        if (Mathf.Abs(player.rb.velocity.x) < player.maxspeed || Input.GetAxis("Horizontal") * player.rb.velocity.x < 0)
        {
            player.rb.velocity += Vector2.right * (Input.GetAxis("Horizontal") * player.acceleration * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            player.transform.localScale = new Vector3(-1f,1f,1f);
            if (player.grounded)
            {
                player.animator.SetBool("walking", true);
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            player.transform.localScale = new Vector3(1f,1f,1f);
            if (player.grounded)
            {
                player.animator.SetBool("walking", true);
            }
        }
    }

    public void Decelerate(Playermovement player)
    {
        if  (player.grounded && player.rb.velocity.y < 0.01f && (Input.GetAxis("Horizontal") == 0 || Mathf.Abs(player.rb.velocity.x) > 1.05f*player.maxspeed))
        {
            player.rb.velocity -= new Vector2(player.rb.velocity.x, 0) * (player.deceleration * Time.deltaTime);
        }
    }

    private void Jump(Playermovement player)
    {
          player.TransitionToState(player.JumpingState, 0.8f);
          
    }
}
