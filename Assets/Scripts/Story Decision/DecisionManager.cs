using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import the SceneManager namespace

public class DecisionManager : MonoBehaviour
{

    public Text decisionText; // UI Text element to display decisions options
    public Button option1Button; // UI for option 1
    public Button option2Button; // UI for option 2 
    public static bool option1Taken = false;
    public static bool option2Taken = false;

    private bool decisionMade = false; // Flag to track if a decision has been made


    void Start()
    {
        // Initialize UI elements and event listners
        option1Button.onClick.AddListener(ChooseOption1);
        option2Button.onClick.AddListener(ChooseOption2);

        option1Button.gameObject.SetActive(true);
        option2Button.gameObject.SetActive(true);
        
        if(option1Taken)
        {
            option1Button.gameObject.SetActive(false);
        }
        if(option2Taken)
        {
            option2Button.gameObject.SetActive(false);
        }

    }


    void Update()
    {
        // check if a decision has been made
        if (!decisionMade)
        {
            // Display decision options
            decisionText.text = "Which path will you choose?";
            


        }
        



    }

    void ChooseOption1()
    {
        // Handle option 1 selection
        Debug.Log("You Chose option 1!");
        PageController.currentIndex = 7;
        SceneManager.LoadScene("Paiges");
        // update game state based on the chosen option
        option1Taken = true;
        decisionMade = true;
        
    }

    void ChooseOption2()
    {
        // Handle option 2 Selection
        Debug.Log("You chose option 2!");
        PageController.currentIndex = 12;
        SceneManager.LoadScene("Paiges");
        // update game state based on the chosen option
        option2Taken = true;
        decisionMade = true;
    }

}
