using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 8f;
    private float currentSpeed;

    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [SerializeField] public float raycastDistance = 0.5f;

    private InputActions controls;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new InputActions();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        Movement();
        Sprint();
        Jump();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        // Adjust Raycast to the bottom of the player
        Vector3 raycastOrigin = transform.position + Vector3.down * (GetComponent<Collider2D>().bounds.extents.y);

        // Perform Raycast and check if the collider has the "Ground" tag
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance);
        isGrounded = hit.collider != null && hit.collider.CompareTag("Ground");
    }

    private void Movement()
    {
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        rb.velocity = new Vector2(input.x * currentSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (controls.Player.Jump.IsPressed() && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Sprint()
    {
        currentSpeed = controls.Player.Run.IsPressed() ? sprintSpeed : walkSpeed;
    }

    private void FlipSprite()
    {
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();

        // Flip the sprite using SpriteRenderer
        if (input.x > 0)
        {
            sprite.flipX = false; // Facing right
        }
        else if (input.x < 0)
        {
            sprite.flipX = true; // Facing left
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the raycast for debugging
        Gizmos.color = Color.red;
        Vector3 raycastOrigin = transform.position + Vector3.down * (GetComponent<Collider2D>().bounds.extents.y);
        Gizmos.DrawLine(raycastOrigin, raycastOrigin + Vector3.down * raycastDistance);
    }
}
