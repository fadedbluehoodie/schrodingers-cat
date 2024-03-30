using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionManager : MonoBehaviour
{

    public Text decisionText; // UI Text element to display decisions options
    public Button option1Button; // UI for option 1
    public Button option2Button; // UI for option 2 

    private bool decisionMade = false; // Flag to track if a decision has been made


    void Start()
    {
        // Initialize UI elements and event listners
        option1Button.onClick.AddListener(ChooseOption1);
        option2Button.onClick.AddListener(ChooseOption2);

    }


    void Update()
    {
        // check if a decision has been made
        if (!decisionMade)
        {
            // Display decision options
            decisionText.text = "Which path will you choose?";
            option1Button.gameObject.SetActive(true);
            option2Button.gameObject.SetActive(true);


        }
        else
        {

            // Hide decision options after a decision has been made
            option1Button.gameObject.SetActive(false);
            option2Button.gameObject.SetActive(false);
        }



    }

    void ChooseOption1()
    {
        // Handle option 1 selection
        Debug.Log("You Chose option 1!");
        // update game state based on the chosen option
        
        decisionMade = true;
    }

    void ChooseOption2()
    {
        // Handle option 2 Selection
        Debug.Log("You chose option 2!");
        // update game state based on the chosen option

        decisionMade = true;

    }

}
