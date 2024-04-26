using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class AstSpawn : MonoBehaviour
{

    [SerializeField] GameObject Asteroid;
    [SerializeField] GameObject charTracker;
    private int normalChance;
    private int characterChance;
    private int selectedNumber;
    private bool finishedCorut = true;
    // Start is called before the first frame update
    void Start()
    {
        finishedCorut = false;
        StartCoroutine(SpawnAsteroids(0, 40, 35));

        normalChance = 4;
        characterChance = 1;
        Debug.Log(normalChance);
        Debug.Log(normalChance + (2 * characterChance));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < 35 && finishedCorut)
        {
            finishedCorut = false;
            StartCoroutine(SpawnAsteroids(50, 60, 1));
        }
        
    }

    IEnumerator SpawnAsteroids(float lowBounds, float upBounds, int repeats)
    {
        for(int i = 0; i < repeats; i++)
        {
            Vector2 pos = Vector2.zero;
            bool selectedPos = false;
            while(selectedPos == false)
            {
                pos = RandomInCircle(upBounds);
                if(Vector2.Distance(Vector2.zero, pos) > lowBounds)
                {
                    selectedPos = true;
                }
            }
            GameObject SpawnedAsteroid = (GameObject)Instantiate(Asteroid, pos, Quaternion.identity, this.transform);
            SpawnedAsteroid.GetComponent<Asteroid>().charTrack = charTracker;
            
            selectedNumber = Random.Range(0, normalChance + (2 * characterChance));
            yield return null;
            Debug.Log(selectedNumber);

            if(selectedNumber >= characterChance + normalChance)
            {
                SpawnedAsteroid.GetComponent<Asteroid>().variant = "Sydney";
                Debug.Log("Sydney Asteroid Incoming");
            }
            else if(selectedNumber >= normalChance)
            {
                SpawnedAsteroid.GetComponent<Asteroid>().variant = "Ishmael";
                Debug.Log("Ishmael Asteroid Incoming");
            }
        }
        finishedCorut = true;
    }

    private Vector2 RandomInCircle(float radius)
    {
        return Random.onUnitSphere * radius;
    }
}
