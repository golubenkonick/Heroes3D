using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementController : MonoBehaviour
{
    public GameObject hexGridObject;
   

    // Start is called before the first frame update
    void Start()
    {
        HexCell cell = HexGrid.Instance.cells[3];
        Debug.Log(cell.coordinates);
        transform.position = HexGrid.Instance.cells[3].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
