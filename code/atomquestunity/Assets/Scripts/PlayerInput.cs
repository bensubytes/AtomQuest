
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public GameObject effect;
    public Animator animator1;
    public Animator animator2;
    public Vector3 mouseScreenPos;
    public Camera mainCam;
    public Vector3 mouseWorldPos;
    public GameObject player;
    public Vector2 targetPos;
    public float speed;
    public bool isMoving;
    public bool collectable = false;
    public KnowledgeManager knowledgeManager;
    public float requiredKnowledge = 6f;
    private bool canMove = true;
    private RaycastHit2D hit;
    public TextMeshProUGUI textTMP;
    public Image greenLight;
    public AnimationData[] playerAnimations;
    public Transform playerTransform;
    public void SetCanMove(bool move)
    {
        canMove = move;
    }

   

    void Update()
    {
        if (canMove && Camera.main != null)
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
                                knowledgeManager.FeedbackAudio(knowledgeManager.rightClip);
                            }
                            else if (hit.collider.CompareTag("Obstacle"))
                            {
                                if (collectable || knowledgeManager.HasEnoughKnowledge(requiredKnowledge))
                                {
                                    BoxCollider2D boxCollider2D = hit.collider.GetComponent<BoxCollider2D>();
                                    boxCollider2D.enabled = false;
                                }
                                else
                                {
                                    Debug.Log("Not enough knowledge to pass through the obstacle.");
                               
                                }
                            }
                            else if (hit.collider.CompareTag("Quiz"))
                            {
                                if (knowledgeManager.HasEnoughKnowledge(requiredKnowledge))
                                {
                                    BoxCollider2D boxCollider2D = hit.collider.GetComponent<BoxCollider2D>();
                                    boxCollider2D.enabled = false;
                                    if (textTMP != null)
                                    {
                                        textTMP.gameObject.SetActive(false);
                                    }
                                    
                                    if (greenLight != null)
                                    {
                                        greenLight.gameObject.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Not enough knowledge to pass through the obstacle.");
                                    
                                }
                            }
                        }
                    }
             /*if (levelTimer != null && levelTimer.currentTime <= 0)
             {
                 knowledgeManager.ResetKnowledge();
             }*/
        }
       
    }




    private void FixedUpdate()
    {
        if (isMoving)
        {

            Vector3 newPosition = Vector3.MoveTowards(player.transform.position, targetPos, speed);

            Collider2D obstacleCollider = Physics2D.OverlapCircle(newPosition, player.GetComponent<Collider2D>().bounds.size.x / 2, LayerMask.GetMask("Obstacle"));
        
            if (obstacleCollider == null)
            {
            
                player.transform.position = newPosition;
            }
            else
            {
                
                isMoving = false;
            }

           
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