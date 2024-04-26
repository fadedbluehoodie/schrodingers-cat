using UnityEngine;

public class Rock : MonoBehaviour
{
    public PlayerController1 PC1;
    public PlayerController2 PC2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            PC1.UseTool1();
        }
        else if (other.CompareTag("Player2"))
        {
            PC2.UseTool2();
        }

        // Check if both players have used their tools before destroying the rock
        if (PC1.destroy1 && PC2.destroy2)
        {
            Destroy(gameObject);
        }
    }
}
