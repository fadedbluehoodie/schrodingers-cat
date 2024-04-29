using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipScript : MonoBehaviour
{
    [SerializeField] GameObject blackHole;
    [SerializeField] GameObject mainCamera;
    [SerializeField] float originalFlySpeed;
    private float flySpeed;
    private float blackDist;
    [SerializeField] float fallSpeed;


    private bool hitStun = false;
    private bool hitTimer = false;
    private bool invincible = false;
    
    public bool isConsumed = false; //Is called by BlackHole script

    private bool turnedUp = false;
    private SpriteRenderer sr;
    [SerializeField] float escapeRange;

    public float fuel;

    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite hitSprite;
    // Start is called before the first frame update
    void Start()
    {
        fuel = 100;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateShip(); //Rotates Ship around Black Hole
        PullToBlack(); //Pulls ship into black hole when idling
        MoveUp(); //Moves ship up when pressing the space key
        
        if(hitTimer)
        {
            StartCoroutine(ResetHitstun(2, 2)); //Resets Hitstun and gives Invincibility
        }

        Escape(); //Checks if player has escaped
        
        blackDist = Vector2.Distance(blackHole.transform.position, transform.position);

        FuelMonitor(); //Adjusts fuel value
        
    }

    void RotateShip()
    {
        if(blackDist <= escapeRange)
        {
            flySpeed = (float)(-Math.Pow(blackDist, 2)/escapeRange + originalFlySpeed);
        }
        else {flySpeed = 0;}
        transform.RotateAround(blackHole.transform.position, new Vector3(0, 0, 1), flySpeed * Time.deltaTime);
    }
    void PullToBlack()
    {
        transform.position = Vector2.MoveTowards(transform.position, blackHole.transform.position, 1 * fallSpeed * Time.deltaTime);
    }
    void MoveUp()
    {
        if(Input.GetKey("space") && !hitStun  && !isConsumed && fuel > 0)
        {
            transform.Translate(Vector2.up * 2 * fallSpeed * Time.deltaTime);
            if(!turnedUp)
            {
                transform.Rotate(0, 0, -30);
                mainCamera.transform.Rotate(0, 0, 30);
                turnedUp = true;
            }
        }
        else if(turnedUp)
        {
            transform.Rotate(0, 0, 30);
            mainCamera.transform.Rotate(0, 0, -30);
            turnedUp = false;
        }
    }

    IEnumerator ResetHitstun(int stunSecs, int invincSecs)
    {
        hitTimer = false;
        invincible = true;
        sr.sprite = hitSprite;
        sr.flipX = false;
        yield return new WaitForSeconds(stunSecs);
        
        hitStun = false;
        sr.sprite = normalSprite;
        sr.flipX = true;
        StartCoroutine(InvinceImage(invincSecs));
        yield return new WaitForSeconds(invincSecs);
        
        invincible =  false;
    }

    IEnumerator InvinceImage(float invincSecs)
    {
        yield return new WaitForSeconds(invincSecs*1.75f/10);
        sr.enabled = false;
        yield return new WaitForSeconds(invincSecs*1.25f/10);
        sr.enabled = true;
        yield return new WaitForSeconds(invincSecs*1.75f/10);
        sr.enabled = false;
        yield return new WaitForSeconds(invincSecs*1.25f/10);
        sr.enabled = true;
        yield return new WaitForSeconds(invincSecs*1.75f/10);
        sr.enabled = false;
        yield return new WaitForSeconds(invincSecs*1.25f/10);
        sr.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if(collision2D.CompareTag("Asteroid") && !invincible)
        {
            hitStun = true;
            hitTimer = true;
            collision2D.GetComponent<Asteroid>().isHit = true;
        }
    }

    void Escape()
    {
        if(blackDist >= escapeRange)
        {
            Debug.Log("YOU WIN!");
            fallSpeed = 0;
            PageController.currentIndex = 20;
            SceneManager.LoadScene("Paiges");
        }
    }

    void FuelMonitor()
    {
        if(turnedUp)
        {
            fuel -= 5 * Time.deltaTime;
        }
        else
        {
            fuel -= 1 * Time.deltaTime;
        }

        if(fuel < 0 && blackDist <= escapeRange)
        {
            fallSpeed *= 1.002f;
            originalFlySpeed *= 1.002f;
        }
    }
}
