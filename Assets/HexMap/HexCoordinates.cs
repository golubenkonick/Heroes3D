using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{

	public int X { get; private set; }

	public int Z { get; private set; }
	
	public int Y => -X - Z;


	public HexCoordinates(int x, int z)
	{
		X = x;
		Z = z;
		
		
	}
	public static HexCoordinates FromOffsetCoordinates(int x, int z)
	{
		return new HexCoordinates(x, z);
	}
	public override string ToString()
	{
		return "(" +
			X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
	}

	public string ToStringOnSeparateLines()
	{
		return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
	}


	// HexCoordinates p1 = new HexCoordinates(1,3);
	// HexCoordinates p2 = new HexCoordinates(1,3);
	// p1 == p2 // false
	// p1.Equals(p2); // true
	// p1.Equals("hello") // false
	// p1.Equals(null); // false

	public override bool Equals(object obj)
    {
		if ((obj == null) || (obj is not HexCoordinates))
		{
			return false;
		}
		else
		{
			HexCoordinates p = (HexCoordinates)obj;
			return (X == p.X) && (Z == p.Z);
		}
	}




}