using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharTrack : MonoBehaviour
{
    public string selectChar;
    // Start is called before the first frame update
    void Start()
    {
        selectChar = "Ishmael";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && selectChar == "Sydney")
        {
            selectChar = "Ishmael";
        }
        if(Input.GetKeyDown(KeyCode.E) && selectChar == "Ishmael")
        {
            selectChar = "Sydney";
        }
    }
}
