using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 10f; // Adjust this in the Inspector to make the ball faster/slower

    private Rigidbody2D rb;
    private Vector2 movementInput;

    void Start()
    {
        // Grabs the Rigidbody2D component from the ball when the game starts
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Gather player input in Update()
        // GetAxisRaw makes the movement snappy. Use GetAxis for an "icy" slide effect.
        movementInput.x = Input.GetAxisRaw("Horizontal"); // A/D keys or Left/Right arrows
        movementInput.y = Input.GetAxisRaw("Vertical");   // W/S keys or Up/Down arrows
        
        // Normalize the vector so moving diagonally isn't faster than moving straight
        movementInput = movementInput.normalized; 
    }

    void FixedUpdate()
    {
        // 2. Apply physics in FixedUpdate()
        // We use AddForce to push the ball, giving it a natural rolling momentum
        rb.AddForce(movementInput * speed);
    }
}