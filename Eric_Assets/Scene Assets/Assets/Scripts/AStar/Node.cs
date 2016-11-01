using UnityEngine;
using System.Collections;

public class Node {

	public Point GridPosition{ get; set;}

	public TileScript TileRef { get; private set;}

	public Node (TileScript tileRef) {
		this.TileRef = tileRef;
		this.GridPosition = tileRef.GridPosition;
	}


}
