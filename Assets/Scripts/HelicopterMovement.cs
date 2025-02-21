using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (gameManager != null && gameManager.IsInputEnabled())
        {
            // Get input from arrow keys
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");

            //Flipping helicopter facing direction to align with movement direction
            if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            moveInput = Vector2.zero;
            Debug.Log("Input Disabled");
        }
    }

    void FixedUpdate()
    {
        // Move the helicopter
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void ApplyWindForce(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}