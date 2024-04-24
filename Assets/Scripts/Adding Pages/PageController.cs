using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Linq;

public class PageController : MonoBehaviour
{

    //List of Pannels. This will get LONG
    [SerializeField] GameObject Sydney2;
    [SerializeField] GameObject Sydney3;
    [SerializeField] GameObject Sydney4;
    List<GameObject> pageIndex = new List<GameObject>();
    int currentIndex = -1;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        //This is gonna suuuck
        pageIndex.Add(Sydney2);
        pageIndex.Add(Sydney3);
        pageIndex.Add(Sydney4);

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
