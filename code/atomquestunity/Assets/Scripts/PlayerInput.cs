using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private KnowledgeManager knowledgeManager;
    [SerializeField] private float requiredKnowledge = 6f;
    [SerializeField] private TextMeshProUGUI textTMP;
    [SerializeField] private Image greenLight;

    private bool canMove = true;
    private Vector2 targetPos;
    private RaycastHit2D hit;
    private bool isMoving;
    private bool collectable;

    public void SetCanMove(bool move)
    {
        canMove = move;
    }

    private void Update()
    {
        if (!canMove || Camera.main == null)
            return;

        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
            hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                switch (hit.collider.tag)
                {
                    case "Background":
                        targetPos = mouseWorldPos;
                        isMoving = true;
                        CheckSpriteFlip();
                        break;
                    case "Collectable":
                        hit.collider.gameObject.SetActive(false);
                        collectable = true;
                        knowledgeManager.FeedbackAudio(knowledgeManager.rightClip);
                        break;
                    case "Obstacle":
                    case "Quiz":
                        HandleObstacleOrQuiz(hit.collider);
                        break;
                }
            }
        }
    }

    private void HandleObstacleOrQuiz(Collider2D collider)
    {
        if (!collectable && !knowledgeManager.HasEnoughKnowledge(requiredKnowledge))
        {
            
            return;
        }

        collider.enabled = false;

        if (collider.CompareTag("Quiz"))
        {
            if (textTMP != null)
                textTMP.gameObject.SetActive(false);

            if (greenLight != null)
                greenLight.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
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
            
        }
    }

    private void CheckSpriteFlip()
    {
        player.GetComponent<SpriteRenderer>().flipX = player.transform.position.x > targetPos.x;
    }
}
