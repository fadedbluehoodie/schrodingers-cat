using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a specific tag (e.g., "Obstacle")
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Handle collision with obstacles (e.g., decrease health, play sound, etc.)
            Debug.Log("Collided with obstacle!");
        }
        // Check if the collision is with another character
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Handle collision with another character (e.g., initiate combat, trigger dialogue, etc.)
            Debug.Log("Collided with another character!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger collision is with a specific tag (e.g., "Item")
        if (other.gameObject.CompareTag("Item"))
        {
            // Handle trigger collision with items (e.g., collect item, increase score, etc.)
            Debug.Log("Collided with item!");
        }
    }
}
