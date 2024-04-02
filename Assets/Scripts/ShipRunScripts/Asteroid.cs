using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float fallSpeed;
    public bool isHit = false; //Is called by ShipScript
    void Start()
    {
        
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
    }
    void PullToBlack()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), 1 * fallSpeed * Time.deltaTime);
    }
}
