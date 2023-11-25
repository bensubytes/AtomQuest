using UnityEngine;

public class Playermovement : MonoBehaviour
{
    

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public SpriteRenderer sr;
    [SerializeField] public BoxCollider2D coll;
    [SerializeField] public Animator animator;

    protected PlayerBaseState currentState;
    protected PlayerBaseState previousState;

    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerJumpingState JumpingState = new PlayerJumpingState();


    [Header("Movement")] public float acceleration = 50f;
    public float deceleration = 15f;
    public float maxspeed = 4f;
    
    public bool grounded;

    public Vector3 spawnposition;
    [SerializeField] public Vector2[] collisionPoints;


    [Header("GameDifficulties")] [SerializeField]
    public GameObject timer;

    [SerializeField] public GameObject actionscanavs;
    [SerializeField] public GameObject scorecanvas;

    protected virtual void Start()
    {
        TransitionToState(IdleState);

        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
       
        
        spawnposition = transform.position;

        /*collisionPoints[0] = new Vector2(coll.size.x / 2, coll.size.y / 2);
        collisionPoints[1] = new Vector2(coll.size.x / 2, 0);
        collisionPoints[2] = new Vector2(coll.size.x / 2, -coll.size.y / 2);
        collisionPoints[3] = new Vector2(-coll.size.x / 2, coll.size.y / 2);
        collisionPoints[4] = new Vector2(-coll.size.x / 2, 0);
        collisionPoints[5] = new Vector2(-coll.size.x / 2, -coll.size.y / 2);*/
        
    }

    protected void Update()
    {
        CheckForGround();
        Checkifidle();

        Walk();
        Decelerate();

        currentState.Update(this);

        animator.SetBool("grounded", grounded);
        animator.SetFloat("verticalSpeed", rb.velocity.y);

        
    }

    public void TransitionToState(PlayerBaseState state, float modifier)
    {
        previousState = currentState;
        currentState = state;
        currentState.EnterState(this, modifier);
    }

    public void TransitionToState(PlayerBaseState state)
    {
        previousState = currentState;
        currentState = state;
        currentState.EnterState(this, 1);
    }

    

    protected void Walk()
    {
        currentState.Walk(this);
    }

    protected void Decelerate()
    {
        currentState.Decelerate(this);
    }
    
    

    protected void CheckForGround()
    {
        int layermask = (1 << 8) + (1 << 10);
        layermask = ~layermask;
        if ((Physics2D.Raycast(coll.bounds.center + new Vector3(coll.size.x / 2f, 0), Vector2.down,
                 coll.size.y / 2f + 0.05f, layermask) &&
             !Physics2D.Raycast(coll.bounds.center + new Vector3(coll.size.x / 2f, 0), Vector2.down, coll.size.y / 2f,
                 layermask)) ||
            (Physics2D.Raycast(coll.bounds.center + new Vector3(-coll.size.x / 2f, 0), Vector2.down,
                 coll.size.y / 2f + 0.05f, layermask) &&
             !Physics2D.Raycast(coll.bounds.center + new Vector3(-coll.size.x / 2f, 0), Vector2.down, coll.size.y / 2f,
                 layermask)))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    protected void Checkifidle()
    {
        currentState.CheckIfIdle(this);
    }

    protected void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }
    
    

    public PlayerBaseState CurrentState
    {
        get => currentState;
        set => currentState = value;
    }

    public PlayerBaseState PreviousState
    {
        get => previousState;
        set => previousState = value;
    }

    /*protected void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(coll.bounds.center, Vector3.down * (coll.size.y / 2f));
        Gizmos.DrawRay(coll.bounds.center + new Vector3(coll.size.x / 2f, 0), Vector3.down * (coll.size.y / 2f));
        Gizmos.DrawRay(coll.bounds.center + new Vector3(-coll.size.x / 2f, 0), Vector3.down * (coll.size.y / 2f));

        Gizmos.color = Color.red;
        Gizmos.DrawRay(coll.bounds.center + new Vector3(0, 0.01f), Vector3.right * (coll.size.x / 2f + 0.1f));
        Gizmos.DrawRay(coll.bounds.center + new Vector3(0, 0.01f), Vector3.left * (coll.size.x / 2f + 0.1f));
        Gizmos.DrawRay(coll.bounds.center + new Vector3(0.01f, 0), Vector3.down * (coll.size.y / 2f + 0.05f));
        Gizmos.DrawRay(coll.bounds.center + new Vector3(coll.size.x / 2f + 0.01f, 0),
            Vector3.down * (coll.size.y / 2f + 0.05f));
        Gizmos.DrawRay(coll.bounds.center + new Vector3(-coll.size.x / 2f + 0.01f, 0),
            Vector3.down * (coll.size.y / 2f + 0.05f));

        foreach (var point in collisionPoints)
        {
            Gizmos.DrawSphere(((Vector3)point + coll.bounds.center), 0.05f);
        }
    }*/

}
