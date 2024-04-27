using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFlyTutorial : MonoBehaviour
{
    bool turnedUp = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
        {
            if(!turnedUp)
            {
                transform.Rotate(0, 0, -30);
                turnedUp = true;
            }
        }
        else if(turnedUp)
        {
            transform.Rotate(0, 0, 30);
            turnedUp = false;
        }
    }
}
