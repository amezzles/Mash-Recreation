using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from arrow keys
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Move the helicopter
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
