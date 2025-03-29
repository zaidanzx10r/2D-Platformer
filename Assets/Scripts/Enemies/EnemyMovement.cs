using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;

    private Transform targetPoint;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        targetPoint = pointA;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Move the enemy towards the current target point
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Check if the enemy reached the target point
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // Switch to the other point
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }

        FlipSprite();
    }

    private void FlipSprite()
    {
        if (targetPoint.position.x > transform.position.x)
        {
            // Moving right: face right
            spriteRenderer.flipX = true;
        }
        else if (targetPoint.position.x < transform.position.x)
        {
            // Moving left: face left
            spriteRenderer.flipX = false;
        }
    }
}
