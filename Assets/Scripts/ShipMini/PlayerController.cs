using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control movement speed
    private bool hasTool = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize movement vector to maintain consistent speed in all directions
        movement.Normalize();

        // Move the player
        rb.velocity = movement * moveSpeed;
    }

    public void CollectTool()
    {
        hasTool = true;
    }


    public void UseTool(Collider2D rockCollider)
    {
        if (hasTool && rockCollider.CompareTag("Rock"))
        {
            // Destroy the rock obstacle
            Destroy(rockCollider.gameObject);
        }



    }
}
