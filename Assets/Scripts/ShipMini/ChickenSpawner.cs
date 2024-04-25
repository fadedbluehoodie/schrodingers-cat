using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    public GameObject chickenPrefab;
    public Transform spawnPoint;

    void Start()
    {
        Timer.OnTimeElapsed += SpawnChicken;
    }

    void SpawnChicken()
    {
        Instantiate(chickenPrefab, spawnPoint.position, Quaternion.identity);
    }
}
