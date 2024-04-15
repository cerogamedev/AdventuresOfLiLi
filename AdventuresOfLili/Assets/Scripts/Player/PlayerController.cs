using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController>
{
    [Header("Move&Jump")]
    public float moveSpeed = 10f;
    public float jumpPower = 30f;
    [SerializeField] private LayerMask jumpableGround;

    [Header("Coyote")]
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [SerializeField] private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private Rigidbody2D rb;
    private BoxCollider2D coll;

    public bool canMove = true;

    public InputHandler inputHandler;

    private IState currentState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        inputHandler = GetComponent<InputHandler>();
    }
    private void Start()
    {
        currentState = new IdleState();
        currentState.EnterState(this);
    }
    public void ChangeState(IState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
    public void Update()
    {
        currentState.UpdateState(this);
        canMove = !DialogueManager.Instance.isInDialogue;
        JumpLogic();
        WalkLogic();
    }
    public void JumpLogic()
    {
        var jumpInput = inputHandler.GKeyDown;
        var jumpInputReleased = inputHandler.GKeyUp;

        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0 && canMove)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpBufferCounter = 0f;
        }
        if (jumpInputReleased && rb.velocity.y > 0f && canMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            coyoteTimeCounter = 0;
        }

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (jumpInput)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }
    public void WalkLogic()
    {
        Vector2 pos = transform.position;

        var horizontalMove = inputHandler.GetMovementAxis();

        if (canMove)
            pos.x += horizontalMove * moveSpeed * Time.deltaTime;

        transform.position = pos;
    }
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    public bool IsWalking()
    {
        return Mathf.Abs(inputHandler.GetMovementAxis()) > 0;
    }
}

