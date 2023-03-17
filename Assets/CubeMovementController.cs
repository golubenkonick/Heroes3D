using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding;


public class CubeMovementController : MonoBehaviour
{
    public GameObject hexGridObject;

    List<HexCell> path;

    int stepNumber = 0;
    float maxDistanceDelta = 0.1f;
    Vector3 velocity;

    public Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        HexCell finish = HexGrid.Instance.cells[0];
        HexCell start = HexGrid.Instance.cells[HexGrid.Instance.cells.Length - 1]; // in python cells[-1];
        Debug.Log("point finish = " + finish);
        Debug.Log("point start = " + start);
        Debug.Log("distance a->b = " + HexGrid.Instance.HeuristicDistance(finish, start));



        Pathfinder<HexCell> mypathfinder = new Pathfinder<HexCell>(HexGrid.Instance.HeuristicDistance, HexGrid.Instance.ConnectedNodesAndStepCosts, 200);
               
        mypathfinder.GenerateAstarPath(start, finish, out path); //A and B are instances of T

        Debug.Log(string.Join(" - ", path));
        transform.position = start.transform.position;
        targetPosition = path[stepNumber].transform.position;
        // Invoke("DoOneStep", 5);

    }

    void DoOneStep()
    {
        if(stepNumber < path.Count)
        {
            transform.position = path[stepNumber].transform.position;
            stepNumber++;
            Invoke("DoOneStep", 0.1f);
        }
      
    }



    // Update is called once per frame
    void Update()
    {
       //  transform.position = Vector3.MoveTowards(transform.position, targetPosition, maxDistanceDelta);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.001f, 100);
        Debug.Log(velocity);
        if (Vector3.Distance(transform.position, targetPosition) <= maxDistanceDelta)
        {
            stepNumber++;
            if (stepNumber < path.Count)
            {
                targetPosition = path[stepNumber].transform.position;
            }
        }
        
    }
}
