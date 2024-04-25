using UnityEngine;

public class Rock : MonoBehaviour
{
    private bool isDestroyed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDestroyed && other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
              //  playerController.UseTool(gameObject);
                isDestroyed = true;
            }
        }
    }
}
