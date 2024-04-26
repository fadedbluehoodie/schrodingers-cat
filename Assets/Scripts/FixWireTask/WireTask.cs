using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour
{
    // Public lists to hold wire colors and assigned left/right wires
    public List<Color> _wireColors = new List<Color>();
    public List<Color> _LeftWires = new List<Color>();
    public List<Color> _RightWires = new List<Color>();

    private void Start()
    {
        // Ensure there are enough colors for each pair of wires
        if (_wireColors.Count < Mathf.Max(_LeftWires.Count, _RightWires.Count))
        {
            Debug.LogError("Not enough colors for wires.");
            return;
        }

        List<int> availableIndices = new List<int>();
        for (int i = 0; i < _wireColors.Count; i++)
        {
            availableIndices.Add(i);
        }

        // Assign colors to wire pairs
        for (int i = 0; i < Mathf.Min(_LeftWires.Count, _RightWires.Count); i++)
        {
            // Choose a random color and assign it to both left and right wires
            int colorIndex = Random.Range(0, availableIndices.Count);
            int color = availableIndices[colorIndex];
            _LeftWires[i] = _RightWires[i] = _wireColors[color];

            // Remove the chosen color from available indices to ensure uniqueness
            availableIndices.RemoveAt(colorIndex);
        }
    }
}
