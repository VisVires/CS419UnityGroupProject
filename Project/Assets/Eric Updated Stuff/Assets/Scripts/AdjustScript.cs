using UnityEngine;
using System.Collections;


public class AdjustScript : MonoBehaviour {

	void OnGUI(){
			
		if (GUI.Button (new Rect (10, 260, 100, 30), "Save")) {
			Pause.pause.Save ();
		}

		if (GUI.Button (new Rect (10, 300, 100, 30), "Load")) {
			Pause.pause.Load ();
		}

	}
}

