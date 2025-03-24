using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActions inputActions;
    private Vector2 moveInput;
    

    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    private float currentSpeed;
    private bool isSprinting = false;

    public float jumpForce = 8f;
    private bool isGrounded;
    
    
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            isSprinting = true;
        }
    }

    public void OnSprintStop(InputAction.CallbackContext context)
    {
        isSprinting = false;
    }

    private void FixedUpdate()
    {
        currentSpeed = isSprinting ? sprintSpeed : walkSpeed;
        rb.linearVelocity = new Vector2(moveInput.x * currentSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
