using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LevelManager : Singleton<LevelManager> {

	//public fields in unity are serialized.
	//to show private members, use SerializeField
	[SerializeField]
	private GameObject[] tiles;

	public Dictionary<Point, TileScript> Tiles { get; set; } 

	//Get the tile sizes
	public float TileSize {
		get {return tiles[0].GetComponent<SpriteRenderer> ().sprite.bounds.size.x;}
	}

	// Use this for initialization
	void Start () {
		Level ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwapInt(int a, int b) {
	
		int tmp = a;
		a = b;
		b = tmp;
	}

	private void Level () {

		Tiles = new Dictionary <Point, TileScript> ();

		string[] map = ReadText ();

		//find the 0th index of the map array and get its length
		int mapX = map[0].ToCharArray ().Length;
		//length of over map array
		int mapY = map.Length;

		//start position will be top left corner of the screen
		Vector3 startPosition = Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height));

		//tiles in 'y' position
		for (int y = 0; y < mapY; y++) {

			char[] newTiles = map [y].ToCharArray ();

			//tiles in 'x' position
			for (int x = 0; x < mapX; x++) {
				PlaceTile (newTiles[x].ToString(),x,y,startPosition);
			}
		}

	}

	private void PlaceTile (string tileType, int x, int y, Vector3 worldStart) {
	
		int tileIndex = int.Parse (tileType);

		TileScript newTile = Instantiate(tiles[tileIndex]).GetComponent<TileScript>();

		newTile.Setup (new Point (x, y), new Vector3 (worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0));

		Tiles.Add (new Point (x, y), newTile);

	}
		
	private string[] ReadText() {
		
		TextAsset bindData = Resources.Load ("Level") as TextAsset;

		string data = bindData.text.Replace (Environment.NewLine, string.Empty);

		return data.Split ('-');
	}
}
