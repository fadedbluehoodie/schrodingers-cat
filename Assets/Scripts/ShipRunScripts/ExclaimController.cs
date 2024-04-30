using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExclaimController : MonoBehaviour
{
    [SerializeField] GameObject charTrack;
    [SerializeField] GameObject alertTrack;
    
    private Image ishExclaim;
    [SerializeField] Sprite ishNormal;
    [SerializeField] Sprite ishExclaiming;
    private Image sydExclaim;
    [SerializeField] Sprite sydNormal;
    [SerializeField] Sprite sydExclaiming;
    // Start is called before the first frame update
    void Start()
    {
        ishExclaim = transform.Find("IshmaelExclaim").GetComponent<Image>();
        sydExclaim = transform.Find("SydneyExclaim").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charTrack.GetComponent<CharTrack>().selectChar != "Ishmael" && alertTrack.GetComponent<FindAst>().ishAlert == true)
        {
            ishExclaim.enabled = true;
            ishExclaim.sprite = ishExclaiming;
        }
        else
        {
            ishExclaim.enabled = false;
            ishExclaim.sprite = ishNormal;
        }
        if(charTrack.GetComponent<CharTrack>().selectChar != "Sydney" && alertTrack.GetComponent<FindAst>().sydAlert == true)
        {
            sydExclaim.enabled = true;
            sydExclaim.sprite = sydExclaiming;
        }
        else
        {
            sydExclaim.enabled = false;
            sydExclaim.sprite = sydNormal;
        }
    }
}
