using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public void EnterState(Playermovement player, float modifier)
    {
    }

    public void Update(Playermovement player)
    {
        //if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (player.Actionsleft > 0))
        if(Input.GetButtonDown("Jump"))
        {
           
            Jump(player);
            //player.SoundManager.JumpingSound.Play();
        }
    }


    public void CheckIfIdle(Playermovement player)
    {
        
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
        player.TransitionToState(player.JumpingState, 1f);
    }
}
