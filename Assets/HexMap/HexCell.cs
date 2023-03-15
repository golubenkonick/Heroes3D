using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;

    public Dictionary<HexCell, float> neighbours = new();
    

    public override string ToString()
    {
        return coordinates.ToString();
    }
}
