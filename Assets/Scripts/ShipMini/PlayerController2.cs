using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control movement speed
    public bool hasTool2 = false;

    private Rigidbody2D rb;
    private PlayerSwitcher playerSwitcher;
    public bool isCurrentPlayer2 = false; // Added to track if this player is the current player
    public bool isTouching2 = false;
    public PlayerSwitcher PS;
    public bool destroy2 = false;
    public PlayerController1 PC1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {

            if (hasTool2)
            {
                if (PC1.isTouching1)
                {

                    Destroy(other.gameObject);


                    // Load the new scene
                    PageController.currentIndex = 5;
                    SceneManager.LoadScene("Paiges");
                }
            }
        }
            
        
            
    }
    void Update()
    {
        /*
        GameObject currentPlayer = playerSwitcher.GetCurrentPlayer();

        // Check if this player is the current player
        isCurrentPlayer = (currentPlayer == gameObject);

        // Debug log to check if this player is the current player
        Debug.Log(gameObject.name + " is current player: " + isCurrentPlayer);
        */


        // Only process movement input if the player controller is enabled and is the current player

       

        if (Input.GetKeyDown(KeyCode.E))
        {

            isCurrentPlayer2 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
      
            isCurrentPlayer2 = false;
        }
        if (isCurrentPlayer2)
        {
            // Get input axes
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            /* Debug log to check movement input
            Debug.Log(gameObject.name + " horizontal input: " + horizontalInput);
            Debug.Log(gameObject.name + " vertical input: " + verticalInput);
            */

            // Calculate movement direction
            Vector2 movement = new Vector2(horizontalInput, verticalInput);

            // Normalize movement vector to maintain consistent speed in all directions
            movement.Normalize();

            // Move the player
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            // If the player controller is disabled or not the current player, stop movement
            rb.velocity = Vector2.zero;
        }
    }

    public void CollectTool2()
    {
        hasTool2 = true;
    }
    public void UseTool2()
    {
        if (this.CompareTag("Rock"))
        {
            // Destroy the rock obstacle
            isTouching2 = true;
            destroy2 = true;
        }
    }
}
