using UnityEngine;

public class Rock : MonoBehaviour
{
    private bool isDestroyed = false;
    public PlayerController1 PC1;
    public PlayerController2 PC2;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(PC1.hasTool && PC2.hasTool)
        {
            if(PC1.isTouching && PC2.isTouching)
            {
                Destroy(gameObject);
            }
        }
        /*if (!isDestroyed && other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
              //  playerController.UseTool(gameObject);
                isDestroyed = true;
            }
        }*/
    }
}
