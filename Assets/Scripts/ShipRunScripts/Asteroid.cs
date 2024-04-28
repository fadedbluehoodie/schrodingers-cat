using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float fallSpeed;
    public bool isHit = false; //Is called by ShipScript
    
    public string variant; //Is called by AstSpawn script and FindAst script.
    public GameObject charTrack; //Is set by AstSpawn
    private SpriteRenderer rend;
    [SerializeField] Sprite normalAst;
    [SerializeField] Sprite redAst;
    [SerializeField] Sprite blueAst;
    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        variant = "null";
        StartCoroutine(ChooseColor());
    }

    // Update is called once per frame
    void Update()
    {
        PullToBlack(); //Pulls asteroid into black hole when idling
        if(isHit)
        {
            Destroy(gameObject);
        }
        if(transform.position == Vector3.zero)
        {
            Destroy(gameObject);
        }

        ShowVariant(); //Shows or hides variants based on who is selected
    }
    void PullToBlack()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), 1 * fallSpeed * Time.deltaTime);
    }

    void ShowVariant()
    {
        if(variant != "null")
        {
            if(variant != charTrack.GetComponent<CharTrack>().selectChar)
            {
                rend.enabled = false;
            }
            else if(rend.enabled == false)
            {
                rend.enabled = true;
            }
        }
        else
        {
            rend.enabled = true;
            rend.sprite = normalAst;
        }
    }

    IEnumerator ChooseColor()
    {
        yield return new WaitForSeconds(0.1f);
        if(variant == "Sydney")
        {
            rend.sprite = redAst;
        }
        if(variant == "Ishmael")
        {
            rend.sprite = blueAst;
        }
    }
}
