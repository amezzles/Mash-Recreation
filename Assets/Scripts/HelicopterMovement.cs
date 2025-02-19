using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        if (gameManager != null && gameManager.IsInputEnabled())
        {
            // Get input from arrow keys
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
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
}