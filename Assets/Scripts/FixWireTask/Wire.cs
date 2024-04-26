using UnityEngine;

public class Wire : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to this GameObject
    }

    // Method to change the color of the wire
    public void SetColor(Color color)
    {
        spriteRenderer.color = color; // Set the color of the SpriteRenderer component
    }
}
