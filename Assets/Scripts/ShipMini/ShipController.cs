using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float floatForce = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Apply upward force to simulate floating
        rb.AddForce(Vector2.up * floatForce, ForceMode2D.Force);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Example collision handling
        if (collision.gameObject.CompareTag("Player"))
        {
            // Do something when colliding with a player character
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Do something when colliding with an obstacle
        }
    }
   

}