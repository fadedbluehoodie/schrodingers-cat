using UnityEngine;

public class ToolCollectible : MonoBehaviour
{
    public GameObject item1; // Assign the item 1 GameObject in the Inspector
    public GameObject item2; // Assign the item 2 GameObject in the Inspector
    public PlayerController1 PC1;
    public PlayerController2 PC2;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        
            
                // Check which item the collectible is associated with
                if (gameObject == item1)
                {
                    // Call CollectItem1() based on the player's tag
                    if (other.CompareTag("Player1"))
                    {
                        if (PC1 != null)
                        {
                            PC1.CollectTool1();
                    Destroy(gameObject);
                }
                    }
                }
                else if (gameObject == item2)
                {
                    // Call CollectItem2() based on the player's tag
                    if (other.CompareTag("Player2"))
                    {
                        if (PC2 != null)
                        {
                            PC2.CollectTool2();
                    Destroy(gameObject);
                }
                    }
                }
            

            // Destroy the collectible object regardless of the player
            
        
    }
}
