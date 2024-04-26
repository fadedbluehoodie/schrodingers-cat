using UnityEngine;

public class Rock : MonoBehaviour
{
    private bool shouldDestroy = false;

    void Update()
    {
        if (shouldDestroy)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController1 PC1 = other.GetComponent<PlayerController1>();
        PlayerController2 PC2 = other.GetComponent<PlayerController2>();

        if (PC1 != null && PC2 != null)
        {
            if (PC1.hasTool && PC2.hasTool && PC1.isTouching && PC2.isTouching)
            {
                shouldDestroy = true;
            }
        }
    }
}
