using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FixDialogueFor2 : MonoBehaviour
{
    public GameObject panel;
    RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        panel = transform.parent.gameObject;
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rt.sizeDelta != panel.GetComponent<RectTransform>().sizeDelta)
        {
            rt.sizeDelta = panel.GetComponent<RectTransform>().sizeDelta;
        }
    }
}
