using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    public bool consumePlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col2D)
    {
        if(col2D.CompareTag("Asteroid"))
        {
            Destroy(col2D);
        }
        if(col2D.CompareTag("Player"))
        {
            col2D.GetComponent<ShipScript>().isConsumed = true;
            consumePlayer = true;
        }
        Debug.Log("EATEN");
    }
}
