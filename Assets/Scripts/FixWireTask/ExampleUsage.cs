using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    public Wire wire; // Reference to the Wire script attached to the wire GameObject

    void Start()
    {
        // Change the color of the wire to red
        wire.SetColor(Color.red);
    }
}
