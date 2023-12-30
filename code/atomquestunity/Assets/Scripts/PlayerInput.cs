using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public Vector3 mouseScreenPos;
    public Camera mainCam;
    public Vector3 mouseWorldPos;
    public GameObject player;
    public Vector2 targetPos;
    public float speed;
    public bool isMoving;
    public bool collectable = false;
    public KnowledgeManager knowledgeManager;
    public DialogueTrigger dialogueTrigger;
    public float requiredKnowledge = 6f;
    
    private RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseScreenPos = Input.mousePosition;
            mouseWorldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
            hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Background"))
                {
                    targetPos = mouseWorldPos;
                    isMoving = true;
                    CheckSpriteFlip();
                }
                else if (hit.collider.CompareTag("Collectable"))
                {
                    hit.collider.gameObject.SetActive(false);
                    collectable = true;
                }
                else if (hit.collider.CompareTag("Obstacle"))
                {
                    if (collectable || knowledgeManager.HasEnoughKnowledge(requiredKnowledge))
                    {
                        hit.collider.gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Not enough knowledge to pass through the obstacle.");
                        // You may want to add some feedback to the player (e.g., display a message)
                    }
                }
                else if (hit.collider.CompareTag("Quiz"))
                {
                    if (knowledgeManager.HasEnoughKnowledge(requiredKnowledge))
                    {
                        hit.collider.gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Not enough knowledge to pass through the obstacle.");
                        // You may want to add some feedback to the player (e.g., display a message)
                    }
                }
            }
        }
    }




    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 newPosition = Vector3.MoveTowards(player.transform.position, targetPos, speed);

            // Check if the new position collides with an obstacle
            Collider2D obstacleCollider = Physics2D.OverlapCircle(newPosition, player.GetComponent<Collider2D>().bounds.size.x / 2, LayerMask.GetMask("Obstacle"));
        
            if (obstacleCollider == null)
            {
                // No obstacle, move the player
                player.transform.position = newPosition;
            }
            else
            {
                // Obstacle encountered, stop moving
                isMoving = false;
            }

            // Check if the player has reached the target position using Vector2.Equals
            if (Vector2.Equals(new Vector2(player.transform.position.x, player.transform.position.y), targetPos))
            {
                isMoving = false;
                Debug.Log("Reached destination");
                
            }
        }
    }


    void CheckSpriteFlip()
    {
        if (player.transform.position.x > targetPos.x)
        {
            //left
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            //right
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}