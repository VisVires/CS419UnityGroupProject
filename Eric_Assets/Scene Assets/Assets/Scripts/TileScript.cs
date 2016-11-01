using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public Point GridPosition{ get; set; }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Setup(Point gridPos, Vector3 worldPosition) {

		this.GridPosition = gridPos;
		transform.position = worldPosition;

		//LevelManager.Instance.Tiles.Add (gridPos, this);
	

	}
}
