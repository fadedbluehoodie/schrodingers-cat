using UnityEngine;

public class ToolCollectible : MonoBehaviour
{
    public PlayerController1 PC1;
    public PlayerController2 PC2;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming PlayerController script handles tool collection
            /*other.GetComponent<PlayerController>().CollectTool();*/
            Destroy(gameObject);
        }
    }
}
