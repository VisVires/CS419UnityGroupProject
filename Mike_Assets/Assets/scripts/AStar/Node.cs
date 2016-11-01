﻿using UnityEngine;
using System.Collections;
using System;

public class Node 
{
	
	public Point GridPosition { get; private set; }

	public TileScript TileRef { get; private set; }
	
	public Node Parent { get; private set; }
	
	public int G { get; set; }
	
	public int H { get; set; }
	
	public int F { get; set; }
	
	public Node(TileScript tileRef)
	{
		this.TileRef = tileRef;
		this.GridPosition = tileRef.GridPosition;
	}
	
	public void CalcValues(Node parent, Node goal, int gCost)
	{
		this.Parent = parent;
		this.G = parent.G + gCost;
		this.H = ((Math.Abs(GridPosition.x - goal.GridPosition.x)) + Math.Abs((goal.GridPosition.y -GridPosition.y))) * 10;
		this.F = G + H;
	}
}
