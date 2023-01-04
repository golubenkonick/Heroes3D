using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public GameObject prefab;
    public int size = 10;
    public GameObject[][] cells;   
    // Start is called before the first frame update
    void Start()
    {
        //cells = new GameObject[size][];
        //for (int i = 0;i < size; i++)
        //{
        //    cells[i] = new GameObject[i+1];
        //    for (int j = 0; j < i+1; j++)
        //    {
        //        float x = i + this.gameObject.transform.position.x;
        //        float y = 0 + this.gameObject.transform.position.y;
        //        float z = j + this.gameObject.transform.position.z;
        //        Debug.Log($"{x} {y} {z}");
        //        cells[i][j] = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity, this.gameObject.transform) ;
        //    }
        //}








    }
    //public float Distance(Vector2 cell1, Vector2 cell2)
    //{
    //    float dx = Mathf.Abs(cell1.x - cell2.x);
    //    float dy = Mathf.Abs(cell1.y - cell2.y);
    //    float min = Mathf.Min(dx, dy); 
    //    return min*Mathf.Sqrt(2) + Mathf.Abs(dx-dy);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
