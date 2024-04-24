using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PageFly : MonoBehaviour
{

    public bool isGoing = false;
    Vector2 _move  = Vector2.up * 0.1f; //Sets base speed at frame 1

    // Update is called once per frame
    void Update()
    {
        if(isGoing)
        {
            _move *= 1.25f; //Increases speed at every frame
            transform.Translate(_move);
            if(_move.magnitude > 200f) //Once it's moving a certain speed
            {
                Destroy(gameObject);
            }
        }
    }
}
