using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using System.Linq;
using Aoiti.Pathfinding;

public class HexGrid : MonoBehaviour
{
	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;
    public HexCell[] cells;

	public Text cellLabelPrefab;

	Canvas gridCanvas;
	HexMesh hexMesh;


    
    public static HexGrid Instance {get; private set;}

     //List<Roy_T.AStar.Graphs.Node> nodes;

	private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;


        gridCanvas = GetComponentInChildren<Canvas>();
		hexMesh = GetComponentInChildren<HexMesh>();

		cells = new HexCell[height * width];
		for (int z = 0, i = 0; z < height; z++)
		{
			for (int x = 0; x < width; x++)
			{
				CreateCell(x, z, i++);
				
			}
		}


        
      

        foreach (HexCell cell in cells)
        {
            // [1, 0], [-1, 0], [0, 1], // TODO Hometask tuple [1, 0]
            (int X, int Z)[] coords = { (1, 0), (-1, 0), (0, 1), (0, -1), (-1, 1), (1, -1) };

            foreach (var coord in coords)
            {
                HexCell neighborCell = cells.FirstOrDefault(c => 
                    c.coordinates.X == cell.coordinates.X + coord.X 
                    && c.coordinates.Z == cell.coordinates.Z + coord.Z);
               
                if (neighborCell != null)
                {
                    cell.neighbours.Add(neighborCell, 1);
                    // neighbor.Connect(cell);
                }


            }
                    
            #region add edges
            //Node nodeEast = new Node(new Position(node.Position.X+1, node.Position.Y));	
            //if (nodes.TryGetValue(node, out var nodeEastFound))
            //         {
            //	node.Connect(nodeEastFound, speedLimit);
            //}
            //Node nodeWest = new Node(new Position(node.Position.X - 1, node.Position.Y));
            //if (nodes.TryGetValue(node, out var nodeWestFound))
            //{
            //	node.Connect(nodeWestFound, speedLimit);
            //}
            //Node nodeNorthEast = new Node(new Position(node.Position.X, node.Position.Y+1));
            //if (nodes.TryGetValue(node, out var nodeNorthEastFound))
            //{
            //	node.Connect(nodeNorthEastFound, speedLimit);
            //}
            //Node nodeSouthWest = new Node(new Position(node.Position.X, node.Position.Y-1));
            //if (nodes.TryGetValue(node, out var nodeSouthWestFound))
            //{
            //	node.Connect(nodeSouthWestFound, speedLimit);
            //}
            //Node nodeNorthWest = new Node(new Position(node.Position.X - 1, node.Position.Y + 1));
            //if (nodes.TryGetValue(node, out var nodeNorthWestFound))
            //{
            //	node.Connect(nodeNorthWestFound, speedLimit);
            //}
            //Node nodeSouthEast = new Node(new Position(node.Position.X + 1, node.Position.Y -1));
            //if (nodes.TryGetValue(node, out var nodeSouthEastFound))
            //{
            //	node.Connect(nodeSouthEastFound, speedLimit);
            //}
            #endregion

        }


    }
    Dictionary<HexCell, float> ConnectedNodesAndStepCosts(HexCell centerPoint)
    {
        return centerPoint.neighbours;
    }

    void CreateCell(int x, int z, int i)
	{
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		// cell.coordinates = HexCoordinates.FromOffsetCoordinates(x - z / 2, z);
		cell.coordinates = new HexCoordinates(x - z / 2, z);


		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
			new Vector2(position.x, position.z);
		label.text = cell.coordinates.ToStringOnSeparateLines();
	}


    //public static HexCoordinates FromOffsetCoordinates(int x, int z)
    //{
    //	//return new HexCoordinates(x - z / 2, z);
    //	return new HexCoordinates(x,z);
    //}



   

    public float HeuristicDistance(HexCell pointA, HexCell pointB)
    {
        return Mathf.Max(
            Mathf.Abs(pointB.coordinates.Z - pointA.coordinates.Z),
            Mathf.Abs(pointB.coordinates.X - pointA.coordinates.X),
            Mathf.Abs(pointB.coordinates.Y - pointA.coordinates.Y)
        );
    }

    void Start()
	{

		hexMesh.Triangulate(cells);


        #region Roy_T
        //var pathFinder = new PathFinder();
        //var maxAgentSpeed = Velocity.FromKilometersPerHour(140);


        //Node nodeA = nodes.FirstOrDefault(n => n.Position.Equals(new Position(0, 0)));
        //Node nodeB = nodes.FirstOrDefault(n => n.Position.Equals(new Position(5, 0)));


        //var path = pathFinder.FindPath(nodeA, nodeB, maxAgentSpeed);
        //Debug.Log($"type: {path.Type}, distance: {path.Distance}, duration {path.Duration}");

        //Debug.Log(string.Join("\n", path.Edges));
        #endregion


        HexCell a = cells[0]; 
        HexCell b = cells[cells.Length - 1]; // in python cells[-1];
        Debug.Log("point a = " + a);
        Debug.Log("point b = " + b);
        Debug.Log("distance a->b = " + HeuristicDistance(a,b));



        Pathfinder<HexCell> mypathfinder = new Pathfinder<HexCell>(HeuristicDistance, ConnectedNodesAndStepCosts, 200); 
        //Call only once …
        List<HexCell> path; 
        mypathfinder.GenerateAstarPath( b, a, out path); //A and B are instances of T

        Debug.Log(string.Join(" - ",path));

    }

}
