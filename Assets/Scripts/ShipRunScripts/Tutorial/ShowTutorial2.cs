using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorial2 : MonoBehaviour
{
    public void Show()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
