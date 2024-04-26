using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public PlayerController1 PC1;
    public PlayerController2 PC2;
   

    


    public void Switch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PC1.isCurrentPlayer1 = false;
            PC2.isCurrentPlayer2 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            PC1.isCurrentPlayer1 = true;
            PC2.isCurrentPlayer2 = false;
        }
    }
    /*
    void SwitchToPlayer2()
    {
        player1.GetComponent<PlayerController>().enabled = false;
        player2.GetComponent<PlayerController>().enabled = true;
        currentPlayer = player2;
    }

    void SwitchToPlayer1()
    {
        player2.GetComponent<PlayerController>().enabled = false;
        player1.GetComponent<PlayerController>().enabled = true;
        currentPlayer = player1;
    }

    public GameObject GetCurrentPlayer()
    {
        return currentPlayer;
    }*/
}
