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
        player1Controller = player1.GetComponent<PlayerController>();
        player2Controller = player2.GetComponent<PlayerController>();

        currentPlayer = player1;
        currentController = player1Controller;

        // Initialize control
        player1Controller.enabled = true;
        player2Controller.enabled = false;
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
