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
		timerText.text = myTimer.ToString ("f0");
		if (myTimer <= 1) {
			myTimer = 0;
			timerText.text = "Time's up!"; 
		}

		GoToNextLevel ();
	}

	private void GoToNextLevel() {
		if (myTimer <= 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}

}
