using Roy_T.AStar.Graphs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NodeExtension
{
   
    public static void Test(this Roy_T.AStar.Graphs.Node node)
    {
        Debug.Log("Test");
    }




    public static bool Equals(this Roy_T.AStar.Graphs.Node node, object obj)
    {
        Debug.Log("Equals1");
        if (obj is Roy_T.AStar.Graphs.Node)
        {
            Roy_T.AStar.Graphs.Node other = (Roy_T.AStar.Graphs.Node)obj;
            return node.Equals(other);
        }

        return false;
    }

    public static bool Equals(this Roy_T.AStar.Graphs.Node node, Roy_T.AStar.Graphs.Node other)
    {
        Debug.Log ("Equals2"); 
        return node.Position.Equals(other.Position);        
    }

    public static int GetHashCode(this Roy_T.AStar.Graphs.Node node)
    {
        return node.Position.GetHashCode();
        // return -1609761766 + X.GetHashCode() + Y.GetHashCode();
    }





}
