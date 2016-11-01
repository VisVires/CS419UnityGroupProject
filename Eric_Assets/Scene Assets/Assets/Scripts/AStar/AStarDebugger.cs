using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarDebugger : MonoBehaviour {

	[SerializeField]
	private TileScript start, goal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ClickTile ();

		if (Input.GetKeyDown (KeyCode.Space)) {

		
			Debug.Log("Space bar pressed");
		
		}
	}

	private void ClickTile() {

		if (Input.GetMouseButtonDown (0)) {

			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hit.collider != null) {

				TileScript tmp = hit.collider.GetComponent<TileScript> ();

				if (tmp != null) {
				
					if (start == null) {
					
						start = tmp; 
					} else if (goal == null) {

						goal = tmp;
					
					}
					
				}
			
			}
		
		}
	
	}


}
