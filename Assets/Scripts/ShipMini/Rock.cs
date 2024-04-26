using UnityEngine;

public class Rock : MonoBehaviour
{
    private bool shouldDestroy = false;
    public PlayerController1 PC1;
    public PlayerController2 PC2;


    void Update()
    {
        if (shouldDestroy)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {


        PC1.UseTool1();
        PC2.UseTool2();
        
    }
}
