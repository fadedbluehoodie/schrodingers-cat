using UnityEngine;

public class ToolCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming PlayerController script handles tool collection
            other.GetComponent<PlayerController>().CollectTool();
            Destroy(gameObject);
        }
    }
}
