using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI namespace to use Image component

public class Wire : MonoBehaviour
{
    private Image _image; // Private field to store reference to the Image component

    private void Awake()
    {
        _image = GetComponent<Image>(); // Get Image component attached to the same GameObject
    }

    // Public method to set the color of the Image component
    public void SetColor(Color color)
    {
        _image.color = color; // Set the color of the Image component
    }
}
