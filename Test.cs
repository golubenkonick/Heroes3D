using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Test
    {
        public float HeuristicDistance(HexCell pointA, HexCell pointB)
        {
            return Math.Max(
                Math.Abs(pointB.coordinates.Z - pointA.coordinates.Z),
                Math.Abs(pointB.coordinates.X - pointA.coordinates.X)
               
            );
        }
    }
