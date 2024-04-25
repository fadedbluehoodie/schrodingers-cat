using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipGameManager : MonoBehaviour
{
    public static ShipGameManager instance; // Singleton instance of the ShipGameManager

    public Text scoreText;
    private int score;

    void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Keep the GameManager between scene loads
    }

    void Start()
    {
        UpdateScoreUI();
    }

    // Add points to the player's score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // Update the score UI text
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("Score Text is not assigned in the GameManager!");
        }
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
