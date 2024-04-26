using UnityEngine;

public class ToolCollectible : MonoBehaviour
{
    public GameObject item1; // Assign the item 1 GameObject in the Inspector
    public GameObject item2; // Assign the item 2 GameObject in the Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            // Check if the playerController is not null to avoid errors
            if (playerController != null)
            {
                // Check which item the collectible is associated with
                if (gameObject == item1)
                {
                    // Call CollectItem1() based on the player's tag
                    if (other.CompareTag("Player1"))
                    {
                        PlayerController1.CollectItem1();
                    }
                }
                else if (gameObject == item2)
                {
                    // Call CollectItem2() based on the player's tag
                    if (other.CompareTag("Player2"))
                    {
                        PlayerController2.CollectItem2();
                    }
                }
            }

            // Destroy the collectible object regardless of the player
            Destroy(gameObject);
        }
    }
}
