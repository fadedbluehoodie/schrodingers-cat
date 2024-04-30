using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // Reference to the UI button
    public Button startButton;

    // Name of the scene to transition to
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        // Add listener to the button
        startButton.onClick.AddListener(StartGame);
    }

    // Function to start the game
    void StartGame()
    {
        // Load the scene with the specified name
        //SceneManager.LoadScene(sceneToLoad);
        SceneManager.LoadScene(1);
    }
}
