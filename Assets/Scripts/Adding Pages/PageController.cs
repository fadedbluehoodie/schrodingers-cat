using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Linq;

public class PageController : MonoBehaviour
{

    //List of Pannels. This will get LONG
    [SerializeField] GameObject Intro1; //Go to Emergency Restabilization 1
    [SerializeField] GameObject Intro2;
    [SerializeField] GameObject Intro3; //Go to Intro Video
    [SerializeField] GameObject Intro4; //Go to Ship Repair 1
    [SerializeField] GameObject Intro5;
    [SerializeField] GameObject Intro6; //Go to Choice
    [SerializeField] GameObject Ishmael1;
    [SerializeField] GameObject Ishmael2; //Go to Emergency Restabilization 2
    [SerializeField] GameObject Ishmael3;
    [SerializeField] GameObject Ishmael4;
    [SerializeField] GameObject Ishmael5;
    [SerializeField] GameObject Ishmael6; //Go to Ship Repair 2
    [SerializeField] GameObject Ishmael7; //Go back to Choice
    [SerializeField] GameObject Sydney1;
    [SerializeField] GameObject Sydney2; //Go to Emergency Restabilization 3
    [SerializeField] GameObject Sydney3; 
    [SerializeField] GameObject Sydney4;
    [SerializeField] GameObject Sydney5; //Go to Ship Repair 3
    [SerializeField] GameObject Sydney6;
    [SerializeField] GameObject Sydney7; //Go back to Choice
    [SerializeField] GameObject Finale1; //Go to Ship Run game, then Ending Video
    [SerializeField] GameObject Finale2;
    [SerializeField] GameObject Finale3;
    [SerializeField] GameObject Finale4;
    [SerializeField] GameObject Finale5;
    
    List<GameObject> pageIndex = new List<GameObject>();
    int currentIndex = -1;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        //This is gonna suuuck
        pageIndex.Add(Intro1);
        pageIndex.Add(Intro2);
        pageIndex.Add(Intro3);
        pageIndex.Add(Intro4);
        pageIndex.Add(Intro5);
        pageIndex.Add(Ishmael1);
        pageIndex.Add(Ishmael2);
        pageIndex.Add(Ishmael3);
        pageIndex.Add(Ishmael4);
        pageIndex.Add(Ishmael5);
        pageIndex.Add(Ishmael6);
        pageIndex.Add(Ishmael7);
        pageIndex.Add(Sydney1);
        pageIndex.Add(Sydney2);
        pageIndex.Add(Sydney3);
        pageIndex.Add(Sydney4);
        pageIndex.Add(Sydney5);
        pageIndex.Add(Sydney6);
        pageIndex.Add(Sydney7);
        pageIndex.Add(Finale1);
        pageIndex.Add(Finale2);
        pageIndex.Add(Finale3);
        pageIndex.Add(Finale4);
        pageIndex.Add(Finale5);

        NewPage(pageIndex.ElementAt(0)); //Switch this to pageIndex[Whatever] for whichever one you want to start on
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && transform.childCount == 1)
        {
            NewPage(pageIndex[currentIndex + 1]); //This is for standard cases. If we have any special cases, we need an If statement and put this in the Else statment
        }
    }

    void NewPage(GameObject chosenPage)
    {
        if(transform.childCount == 1)
        {
            GameObject oldPage = transform.GetChild(0).gameObject;
            oldPage.GetComponent<PageFly>().isGoing = true; //Flies the old page up
        }
        GameObject newPage = Instantiate(chosenPage, this.transform);
        newPage.transform.SetAsFirstSibling();

        currentIndex = pageIndex.IndexOf(chosenPage);
    }
}
