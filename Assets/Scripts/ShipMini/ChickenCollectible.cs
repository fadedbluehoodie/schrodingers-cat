using UnityEngine;

public class ChickenCollectible : MonoBehaviour
{
    public int points = 100;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShipGameManager.instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
