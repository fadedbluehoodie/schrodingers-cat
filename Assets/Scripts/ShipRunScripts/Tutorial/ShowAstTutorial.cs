using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAstTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
        transform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
            transform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
            transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
        }
    }
}
