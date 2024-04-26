using UnityEngine;

public class WireTask : MonoBehaviour
{
    public Color[] wireColors; // Array of wire colors
    public SpriteRenderer[] leftWires; // Array of left wire SpriteRenderers
    public SpriteRenderer[] rightWires; // Array of right wire SpriteRenderers

    void Start()
    {
        // Assign random colors to left and right wires
        for (int i = 0; i < leftWires.Length; i++)
        {
            int randomColorIndex = Random.Range(0, wireColors.Length);
            leftWires[i].color = wireColors[randomColorIndex];
            rightWires[i].color = wireColors[randomColorIndex];
        }
    }
}
