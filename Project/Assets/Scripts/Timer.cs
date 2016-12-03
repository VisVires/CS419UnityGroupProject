using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {


	public Text timerText;

	public float myTimer = 120; 

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		myTimer -= Time.deltaTime; 
		int intTime = (int)myTimer;
		timerText.text = "TIME REMAINING  " + intTime;
		if (myTimer <= 1) {
			myTimer = 0;
			timerText.text = "LEVEL COMPLETED";
		}
		if (myTimer <= 30) {
			timerText.color = new Color(1,0,0,1);
		}

		GoToNextLevel ();
	}

	private void GoToNextLevel() {
		if (myTimer <= 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			Debug.Log ("LEVEL " + SceneManager.GetActiveScene().buildIndex);
		}
	}

}
