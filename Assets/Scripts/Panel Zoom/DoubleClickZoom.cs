using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DoubleClickZoom : MonoBehaviour, IPointerClickHandler
{
    public bool zoomedIn = false;
    float lastClickTime;
    float catchTime = 0.25f; // Adjust this value to suit your needs
    [SerializeField] float scaleFactor = 5.5f; // Adjust this value to set the zoom level

    Vector2 referencePoint = new Vector2(0.5f, 0.5f); // Center of the panel
    Vector2 originalSize;

    RectTransform rt;
    Vector2 newSize;

    List<GameObject> positions = new List<GameObject>(); //List of child game objects (pannels)
    int currentPannel = -1; //currentPannel being -1 means no pannel is currently selected

    void Start()
    {
        originalSize = GetComponent<RectTransform>().sizeDelta;
        rt = GetComponent<RectTransform>();
        newSize =  new Vector2(rt.rect.width * scaleFactor, rt.rect.height * scaleFactor);
        
        for(int i = 0; i < transform.childCount; i++)
        {
            positions.Add(transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        if(currentPannel != -1)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentPannel++;
                if(currentPannel <= positions.Count) //If there is a pannel available to go to
                {
                    FindPos(Vector2.zero, currentPannel);
                }
                else //If there isn't
                {
                    ZoomOut();
                }
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentPannel--;
                if(currentPannel > 0) //If there is a pannel available to go to
                {
                    FindPos(Vector2.zero, currentPannel);
                }
                else //If there isn't
                {
                    ZoomOut();
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.time - lastClickTime < catchTime)
        {
            if (!zoomedIn)
            {
                FindPos(eventData.position, currentPannel);
            }
            else
            {
                ZoomOut();
                zoomedIn = false;
            }
            lastClickTime = 0;
        }
        else
        {
            lastClickTime = Time.time;
        }
    }

    void FindPos(Vector2 doubleClickPosition, int curPan)
    {
        if(curPan == -1) //If no pannel is currently selected
        {
            for (int i = 0; i < positions.Count; i++)
            {
                var posit = positions[i];
                var positRect = Rect.MinMaxRect(  //Get's the bounds for the pannel size
                    posit.transform.position.x - (posit.GetComponent<SpriteRenderer>().bounds.size.x / 2),
                    posit.transform.position.y - (posit.GetComponent<SpriteRenderer>().bounds.size.x / 2),
                    posit.transform.position.x + (posit.GetComponent<SpriteRenderer>().bounds.size.x / 2),
                    posit.transform.position.y + (posit.GetComponent<SpriteRenderer>().bounds.size.x / 2)
                );
                
                if(positRect.Contains(doubleClickPosition)) //If the click is within the bounds
                {
                    ZoomIn(posit.transform.position);
                    currentPannel = i + 1;
                    Debug.Log(currentPannel);
                }
            }
        }
        else if(curPan != -1) //If a pannel is already selected
        {
            Debug.Log(curPan);
            Debug.Log(positions[curPan - 1]);
            var posit = positions[curPan - 1].transform.position;
            ZoomIn(posit);
        }
    }

    void ZoomIn(Vector2 newPos)
    {
        if(zoomedIn) //If the player is already zoomed in, adjust values.
        {
            Vector2 referenceOffset = new Vector2(
                (referencePoint.x - 0.5f) * rt.rect.width,
                (referencePoint.y - 0.5f) * rt.rect.height
            );
            Vector2 localReferencePoint = new Vector2(
                scaleFactor * ((newPos.x - rt.position.x) / rt.rect.width),
                scaleFactor * ((newPos.y - rt.position.y) / rt.rect.height)
            );
            Vector2 offset = new Vector2(
                (localReferencePoint.x * newSize.x) - referenceOffset.x,
                (localReferencePoint.y * newSize.y) - referenceOffset.y
            );
            rt.sizeDelta = newSize;
            rt.localPosition = localReferencePoint;
            rt.localPosition -= (Vector3)offset;
            zoomedIn = true;
        }
        else //If player isn't already zoomed in, DON'T adjust values
        {
            Vector2 referenceOffset = new Vector2(
                (referencePoint.x - 0.5f) * rt.rect.width,
                (referencePoint.y - 0.5f) * rt.rect.height
            );
            Vector2 localReferencePoint = new Vector2(
                (newPos.x - rt.position.x) / rt.rect.width,
                (newPos.y - rt.position.y) / rt.rect.height
            );
            Vector2 offset = new Vector2(
                (localReferencePoint.x * newSize.x) - referenceOffset.x,
                (localReferencePoint.y * newSize.y) - referenceOffset.y
            );
            rt.sizeDelta = newSize;
            rt.localPosition = localReferencePoint;
            rt.localPosition -= (Vector3)offset;
            zoomedIn = true;
        }
        
    }

    void ZoomOut()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = originalSize;
        rt.localPosition = Vector3.zero;
        currentPannel = -1;
        zoomedIn = false;
    }
}
