using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClickZoom : MonoBehaviour, IPointerClickHandler
{
    bool zoomedIn = false;
    float lastClickTime;
    float catchTime = 0.25f; // Adjust this value to suit your needs
    float scaleFactor = 2f; // Adjust this value to set the zoom level

    Vector2 referencePoint = new Vector2(0.5f, 0.5f); // Center of the panel
    Vector2 originalSize;

    void Start()
    {
        originalSize = GetComponent<RectTransform>().sizeDelta;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.time - lastClickTime < catchTime)
        {
            if (!zoomedIn)
            {
                ZoomIn(eventData.position);
            }
            else
            {
                ZoomOut();
            }
            zoomedIn = !zoomedIn;
            lastClickTime = 0;
        }
        else
        {
            lastClickTime = Time.time;
        }
    }

    void ZoomIn(Vector2 doubleClickPosition)
    {
        RectTransform rt = GetComponent<RectTransform>();
        Vector2 referenceOffset = new Vector2(
            (referencePoint.x - 0.5f) * rt.rect.width,
            (referencePoint.y - 0.5f) * rt.rect.height
        );
        Vector2 newSize = new Vector2(rt.rect.width * scaleFactor, rt.rect.height * scaleFactor);
        Vector2 localReferencePoint = new Vector2(
            (doubleClickPosition.x - rt.position.x) / rt.rect.width,
            (doubleClickPosition.y - rt.position.y) / rt.rect.height
        );
        Vector2 offset = new Vector2(
            (localReferencePoint.x * newSize.x) - referenceOffset.x,
            (localReferencePoint.y * newSize.y) - referenceOffset.y
        );
        rt.sizeDelta = newSize;
        rt.localPosition -= (Vector3)offset;
    }

    void ZoomOut()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = originalSize;
        rt.localPosition = Vector3.zero;
    }
}
