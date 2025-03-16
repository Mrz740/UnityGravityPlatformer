using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D rb;
    public static Player Instance {  get; private set; }

    private Vector2 moveDir;
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
        HandleJump();
        HandleDirection();
        HandleGravity();

        HandleMovement();
        Debug.Log(rb.linearVelocity.ToString());
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
        //Gravity logic
    }

    private void HandleMovement()
    {
        rb.linearVelocity = moveDir * moveSpeed;
    }

    private bool CheckCollision()
    {
        //Collision logic
        return false;
    }
}
