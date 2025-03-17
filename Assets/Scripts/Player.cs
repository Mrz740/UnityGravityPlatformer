using UnityEngine;

public class Player : MonoBehaviour
{
    private const float GRAVITY = -9.81f;

    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float gravityMultiplier = 1f;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask layer;

    public static Player Instance {  get; private set; }

    private Vector2 moveDir;
    private bool grounded;
    private float velocity;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than 1 player instance");
        }
        Instance = this;
    }

    private void Start()
    {
        gameInput.OnJumpAction += GameInput_OnJumpAction;
    }

    private void GameInput_OnJumpAction(object sender, System.EventArgs e)
    {
        HandleJump();
    }

    private void FixedUpdate()
    {
        IsGrounded();
        HandleJump();
        HandleDirection();
        HandleGravity();

        HandleMovement();
    }
    private void HandleJump()
    {
        //Jump logic
    }

    private void HandleDirection()
    {
        moveDir = gameInput.GetMovementVector();
    }
    private void HandleGravity()
    {
        if (!IsGrounded())
        {
            moveDir = new Vector2(moveDir.x, GRAVITY * gravityMultiplier * Time.deltaTime);
        }
    }

    private void HandleMovement()
    {
        rb.linearVelocity = moveDir * moveSpeed;
    }

    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up,castDistance, layer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //Debug Purposes
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
