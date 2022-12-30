using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] cubes; 


    void Start()
    {
        cubes = new GameObject[50]; 
        cubes[0] = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSave()
    {
        Debug.Log("OnSave in class Map");
    }
}
