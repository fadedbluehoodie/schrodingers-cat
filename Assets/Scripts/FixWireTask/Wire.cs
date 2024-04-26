using UnityEngine;

public class Wire : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer; // Private field to store reference to the SpriteRenderer component

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // Get SpriteRenderer component attached to the same GameObject
    }

    // Public method to set the color of the SpriteRenderer component
    public void SetColor(Color color)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = color; // Set the color of the SpriteRenderer component
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component is missing on the Wire GameObject.");
        }
    }
}
