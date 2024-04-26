using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    public PlayerController1 PC1;
    public PlayerController2 PC2;
    public string sceneToLoad; // Name of the scene to load after destroying the rock

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
            // Destroy the rock
            DestroyRock();
        }
    }

    void DestroyRock()
    {
        // Destroy the rock GameObject
        Destroy(gameObject);

        // Load the new scene
        SceneManager.LoadScene(4);
    }
}
