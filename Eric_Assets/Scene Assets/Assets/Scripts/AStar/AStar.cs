using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AStar  {

	private static Dictionary<Point, Node> nodes;

	private static void CreateNodes() {

		nodes = new Dictionary<Point, Node> ();

		foreach (TileScript tile in LevelManager.Instance.Tiles.Values) {
		
			nodes.Add (tile.GridPosition, new Node (tile));
		
		
		}
			
	}

	public static void GetPath(Point start) {
		
		if (nodes == null) {
		
			CreateNodes();
		}

		HashSet<Node> openList = new HashSet<Node> ();

		Node currentNode = nodes [start];

		openList.Add (currentNode);

		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				Debug.Log (x + ", " + y);
			}
		
		}
	}
}

