//using System.Collections;
//using System.Collections.Generic;
//using Roy_T.AStar.Grids;
//using Roy_T.AStar.Primitives;
//using Roy_T.AStar.Paths;
//using UnityEngine;
//using UnityEngine.UI;
//using Roy_T.AStar.Graphs;
//using System.Linq;

//public class HexGrid1 : MonoBehaviour
//{
//	public int width = 6;
//	public int height = 6;

//	public HexCell cellPrefab;
//    HexCell[] cells;

//	public Text cellLabelPrefab;

//	Canvas gridCanvas;
//	HexMesh hexMesh;

//     List<Roy_T.AStar.Graphs.Node> nodes;

//	private void Awake()
//    {
//		gridCanvas = GetComponentInChildren<Canvas>();
//		hexMesh = GetComponentInChildren<HexMesh>();

//		cells = new HexCell[height * width];
//		for (int z = 0, i = 0; z < height; z++)
//		{
//			for (int x = 0; x < width; x++)
//			{
//				CreateCell(x, z, i++);
				
//			}
//		}


//        nodes = new List<Node>();
//        for (int z = 0, i = 0; z < height; z++)
//        {
//            for (int x = 0; x < width; x++)
//            {
//                var position = new Roy_T.AStar.Primitives.Position(x, z);
//                var node = new Roy_T.AStar.Graphs.Node(position);
//                nodes.Add(node);
//            }
//        }
//        var speedLimit = Velocity.FromMetersPerSecond(5000);    

//        foreach (Node node in nodes)
//        {
//            // [1, 0], [-1, 0], [0, 1], // TODO Hometask tuple [1, 0]
//            (int X, int Y)[] coords = { (1, 0), (-1, 0), (0, 1), (0, -1), (-1, 1), (1, -1) };

//            foreach (var coord in coords)
//            {
//                //Node nodeSearch = new Node(new Position(node.Position.X + coord.X, node.Position.Y + coord.Y));
//                //if (nodes.TryGetValue(nodeSearch, out var nodeFound))
//                //{
//                //    node.Connect(nodeFound, speedLimit);

//                //}
//                Position position = new Position(node.Position.X + coord.X, node.Position.Y + coord.Y);
//                Node nodeFound = nodes.FirstOrDefault(n => n.Position.Equals(position));
//                if (nodeFound != null)
//                {
//                    node.Connect(nodeFound, speedLimit);
//                }
              

//            }

//            #region add edges
//            //Node nodeEast = new Node(new Position(node.Position.X+1, node.Position.Y));	
//            //if (nodes.TryGetValue(node, out var nodeEastFound))
//            //         {
//            //	node.Connect(nodeEastFound, speedLimit);
//            //}
//            //Node nodeWest = new Node(new Position(node.Position.X - 1, node.Position.Y));
//            //if (nodes.TryGetValue(node, out var nodeWestFound))
//            //{
//            //	node.Connect(nodeWestFound, speedLimit);
//            //}
//            //Node nodeNorthEast = new Node(new Position(node.Position.X, node.Position.Y+1));
//            //if (nodes.TryGetValue(node, out var nodeNorthEastFound))
//            //{
//            //	node.Connect(nodeNorthEastFound, speedLimit);
//            //}
//            //Node nodeSouthWest = new Node(new Position(node.Position.X, node.Position.Y-1));
//            //if (nodes.TryGetValue(node, out var nodeSouthWestFound))
//            //{
//            //	node.Connect(nodeSouthWestFound, speedLimit);
//            //}
//            //Node nodeNorthWest = new Node(new Position(node.Position.X - 1, node.Position.Y + 1));
//            //if (nodes.TryGetValue(node, out var nodeNorthWestFound))
//            //{
//            //	node.Connect(nodeNorthWestFound, speedLimit);
//            //}
//            //Node nodeSouthEast = new Node(new Position(node.Position.X + 1, node.Position.Y -1));
//            //if (nodes.TryGetValue(node, out var nodeSouthEastFound))
//            //{
//            //	node.Connect(nodeSouthEastFound, speedLimit);
//            //}
//            #endregion

//        }


//    }
//    void CreateCell(int x, int z, int i)
//	{
//		Vector3 position;
//		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
//		position.y = 0f;
//		position.z = z * (HexMetrics.outerRadius * 1.5f);

//		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
//		cell.transform.SetParent(transform, false);
//		cell.transform.localPosition = position;
//		// cell.coordinates = HexCoordinates.FromOffsetCoordinates(x - z / 2, z);
//		cell.coordinates = new HexCoordinates(x - z / 2, z);


//		Text label = Instantiate<Text>(cellLabelPrefab);
//		label.rectTransform.SetParent(gridCanvas.transform, false);
//		label.rectTransform.anchoredPosition =
//			new Vector2(position.x, position.z);
//		label.text = cell.coordinates.ToStringOnSeparateLines();
//	}


//	//public static HexCoordinates FromOffsetCoordinates(int x, int z)
//	//{
//	//	//return new HexCoordinates(x - z / 2, z);
//	//	return new HexCoordinates(x,z);
//	//}

//	void Start()
//	{

//		hexMesh.Triangulate(cells);


//        #region Roy_T
//        //var pathFinder = new PathFinder();
//        //var maxAgentSpeed = Velocity.FromKilometersPerHour(140);


//        //Node nodeA = nodes.FirstOrDefault(n => n.Position.Equals(new Position(0, 0)));
//        //Node nodeB = nodes.FirstOrDefault(n => n.Position.Equals(new Position(5, 0)));


//        //var path = pathFinder.FindPath(nodeA, nodeB, maxAgentSpeed);
//        //Debug.Log($"type: {path.Type}, distance: {path.Distance}, duration {path.Duration}");

//        //Debug.Log(string.Join("\n", path.Edges));
//        #endregion

//        Node nodeA = nodes.FirstOrDefault(n => n.Position.Equals(new Position(0, 0)));
//        Node nodeB = nodes.FirstOrDefault(n => n.Position.Equals(new Position(5, 0)));


//    }

//}
