using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour
{
    public List<Color> _wireColors = new List<Color>();
    public List<Wire> _LeftWires = new List<Wire>():
     public List<Wire> _RightWires = new List<Wire>():

        private List<colors> _availableColors;
    private List<int> _availableLeftWireIndex;
    private List<int> _availableRightWireIndex;

    private void start()
    {
        _availableColors = new List<colors>(_wireColors);
        _availableLeftWireIndex = new List<int>();
        _availableRightWireIndex = new List<int>();

        for (int i = 0; i < _LeftWires.Count; i++) {_availableLeftWireIndex.Add(i); }
        for (int i = 0; i < _RightWires.Count; i++) { _availableRightWireIndex.Add(i); }





    }
}
