using UnityEngine;

public class WireMatching : MonoBehaviour
{
    private Color? selectedColor = null;
    private GameObject selectedWire = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wire"))
        {
            GameObject wire = other.gameObject;
            Color wireColor = wire.GetComponent<SpriteRenderer>().color;

            // Check if a wire of the same color is already selected
            if (selectedColor == null)
            {
                // Select the first wire
                selectedColor = wireColor;
                selectedWire = wire;
            }
            else
            {
                // Check if the current wire matches the selected color
                if (selectedColor == wireColor)
                {
                    // Wires match, mark them as matched
                    MatchWires(selectedWire, wire);
                }
                else
                {
                    // Wires don't match, deselect the first wire
                    selectedColor = null;
                    selectedWire = null;
                }
            }
        }
    }

    private void MatchWires(GameObject wire1, GameObject wire2)
    {
        // Add logic to handle matched wires
        Debug.Log("Wires matched!");
        // Example: Change wire colors or destroy matched wires
        wire1.GetComponent<SpriteRenderer>().color = Color.white;
        wire2.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
