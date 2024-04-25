using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private PlayerController player1Controller;
    private PlayerController player2Controller;

    private GameObject currentPlayer;
    private PlayerController currentController;

    void Start()
    {
        // Check if player1 GameObject and its PlayerController component are assigned
        if (player1 != null)
        {
            player1Controller = player1.GetComponent<PlayerController>();
            if (player1Controller == null)
            {
                Debug.LogError("PlayerSwitcher: Player1 is missing PlayerController component.");
            }
        }
        else
        {
            Debug.LogError("PlayerSwitcher: Player1 GameObject is not assigned.");
        }

        // Check if player2 GameObject and its PlayerController component are assigned
        if (player2 != null)
        {
            player2Controller = player2.GetComponent<PlayerController>();
            if (player2Controller == null)
            {
                Debug.LogError("PlayerSwitcher: Player2 is missing PlayerController component.");
            }
        }
        else
        {
            Debug.LogError("PlayerSwitcher: Player2 GameObject is not assigned.");
        }

        // Continue with initialization if no errors were encountered
        if (player1Controller != null && player2Controller != null)
        {
            currentPlayer = player1;
            currentController = player1Controller;

            // Initialize control
            player1Controller.enabled = true;
            player2Controller.enabled = false;
        }
        else
        {
            Debug.LogError("PlayerSwitcher: Initialization failed due to missing components.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
        currentController.enabled = false;

        if (currentPlayer == player1)
        {
            currentPlayer = player2;
            currentController = player2Controller;
        }
        else
        {
            currentPlayer = player1;
            currentController = player1Controller;
        }

        currentController.enabled = true;
    }
}
