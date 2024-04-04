using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAst : MonoBehaviour
{

    public bool ishAlert = false;
    public bool sydAlert = false;
    private int ishNumber;
    private int sydNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ishNumber > 0 && !ishAlert)
        {
            ishAlert = true;
        }
        if(ishNumber == 0 && ishAlert)
        {
            ishAlert = false;
        }

        if(sydNumber > 0 && !sydAlert)
        {
            sydAlert = true;
        }
        if(sydNumber == 0 && sydAlert)
        {
            sydAlert = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if(collision2D.CompareTag("Asteroid"))
        {
            if(collision2D.GetComponent<Asteroid>().variant == "Ishmael")
            {
                ishNumber++;
            }
            else if(collision2D.GetComponent<Asteroid>().variant == "Sydney")
            {
                sydNumber++;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision2D)
    {
        if(collision2D.CompareTag("Asteroid"))
        {
            if(collision2D.GetComponent<Asteroid>().variant == "Ishmael")
            {
                ishNumber--;
            }
            else if(collision2D.GetComponent<Asteroid>().variant == "Sydney")
            {
                sydNumber--;
            }
        }
    }
}
