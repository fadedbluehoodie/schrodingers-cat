using UnityEngine.SceneManagement; // Import the SceneManager namespace
using UnityEngine;
using System.Collections.Generic;

public class PageController : MonoBehaviour
{
    [SerializeField] GameObject Intro1; // Go to Emergency Restabilization 1
    [SerializeField] GameObject Intro2;
    [SerializeField] GameObject Intro3;
    [SerializeField] GameObject Intro4; // Go to Intro Video
    [SerializeField] GameObject Intro4dot5; // Go to Ship Repair 1
    [SerializeField] GameObject Intro5;
    [SerializeField] GameObject Intro6; // Go to Choice
    [SerializeField] GameObject Ishmael1;
    [SerializeField] GameObject Ishmael2; // Go to Emergency Restabilization 2
    [SerializeField] GameObject Ishmael3;
    [SerializeField] GameObject Ishmael4_5;
    [SerializeField] GameObject Ishmael6; // Go to Ship Repair 2
    [SerializeField] GameObject Sydney1;
    [SerializeField] GameObject Sydney2; // Go to Emergency Restabilization 3
    [SerializeField] GameObject Sydney3;
    [SerializeField] GameObject Sydney4;
    [SerializeField] GameObject Sydney5; // Go to Ship Repair 3
    [SerializeField] GameObject Sydney6;
    [SerializeField] GameObject Sydney7; // Go back to Choice
    [SerializeField] GameObject Finale1; // Go to Ship Run game, then Ending Video
    [SerializeField] GameObject Finale2_3;
    [SerializeField] GameObject Finale4;
    [SerializeField] GameObject Finale5;

    List<GameObject> pageIndex = new List<GameObject>();





    public static int currentIndex = 0; //Currently Referenced in this script, DecisionManager, ShipGameManager, PlayerController2, ShipScript
                                        //If we do end up adding Ishmael7, UPDATE THE SCRIPTS ABOVE!!!!







    //bool hasVisitedScene = false; // Flag to track if the player has visited the different scene

    // Start is called before the first frame update
    void Start()
    {
        pageIndex.Add(Intro1);
        pageIndex.Add(Intro2);
        pageIndex.Add(Intro3);
        pageIndex.Add(Intro4);
        pageIndex.Add(Intro4dot5);
        pageIndex.Add(Intro5);
        pageIndex.Add(Intro6);
        pageIndex.Add(Ishmael1);
        pageIndex.Add(Ishmael2);
        pageIndex.Add(Ishmael3);
        pageIndex.Add(Ishmael4_5);
        pageIndex.Add(Ishmael6);
        pageIndex.Add(Sydney1);
        pageIndex.Add(Sydney2);
        pageIndex.Add(Sydney3);
        pageIndex.Add(Sydney4);
        pageIndex.Add(Sydney5);
        pageIndex.Add(Sydney6);
        pageIndex.Add(Sydney7);
        pageIndex.Add(Finale1);
        pageIndex.Add(Finale2_3);
        pageIndex.Add(Finale4);
        pageIndex.Add(Finale5);

        /*// Load the stored currentIndex or default to 0
        int storedIndex = PlayerPrefs.GetInt("CurrentPageIndex", -1);

        // If the stored index is valid, use it
        if (storedIndex >= 0 && storedIndex < pageIndex.Count)
        {
            currentIndex = storedIndex;
        }
        // If the player has visited the mini-game scene, start at page 5
        if (PlayerPrefs.GetInt("HasVisitedScene", 0) == 1)
        {
            currentIndex = pageIndex.IndexOf(Intro5);
        }*/

        GameObject chosenPage = pageIndex[currentIndex];
        GameObject newPage = Instantiate(chosenPage, this.transform);
        currentIndex = pageIndex.IndexOf(chosenPage);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.childCount == 1)
        {
            /*if(currentIndex == 3) //Once they're about to take off
            {
                LoadNewScene("IntroVideo"); //Play the video
            }
            else */if(currentIndex == 4) //Once they've crashed...
            {
                LoadNewScene("ShipMini");  //Ship repair game
            }
            else if(currentIndex == 6 || currentIndex == 11 || currentIndex == 18) //If we've finished the Introduction or either Character story
            {
                if(DecisionManager.option1Taken && DecisionManager.option2Taken) //If we've gone through both storylines
                {
                    NewPage(pageIndex[19]); //Start Finale
                }
                else
                {
                    LoadNewScene("Decison"); //Otherwise go back to decision
                }
            }
            else if(currentIndex == 19) //Once they take off...
            {
                LoadNewScene("ShipRunTutorial"); //Go to Ship Run Segment
            }
            else
            {
                NewPage(pageIndex[currentIndex + 1]); // This is for standard cases
            }
        }
    }

    void NewPage(GameObject chosenPage)
    {
        GameObject oldPage = transform.GetChild(0).gameObject;
        if (oldPage.GetComponent<DoubleClickZoom>().zoomedIn == false)
        {
            oldPage.GetComponent<PageFly>().isGoing = true; // Flies the old page up

            currentIndex = pageIndex.IndexOf(chosenPage);

            GameObject newPage = Instantiate(chosenPage, this.transform);
            newPage.transform.SetAsFirstSibling();
        }
    }

    void LoadNewScene(string ShipMini)
    {
        // Load the scene with the given name
        SceneManager.LoadScene(ShipMini);
    }
}
