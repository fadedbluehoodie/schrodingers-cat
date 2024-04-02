using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class AstSpawn : MonoBehaviour
{

    [SerializeField] GameObject Asteroid;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            SpawnAsteroids(0, 40);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < 25)
        {
            SpawnAsteroids(50, 60);
        }
        
    }

    void SpawnAsteroids(float lowBounds, float upBounds)
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
        Debug.Log(Vector2.Distance(Vector2.zero, pos));        
        GameObject SpawnedAsteroid = (GameObject)Instantiate(Asteroid, pos, Quaternion.identity, this.transform);
    }

    private Vector2 RandomInCircle(float radius)
    {
        return Random.onUnitSphere * radius;
    }
}
