using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

	public int score;
	public Text scoreText;


	// Use this for initialization
	void Start () {
		PlayerPrefs.GetInt("scorePref");
		score = PlayerPrefs.GetInt("scorePref");
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreText.name == "scoreText") {
			scoreText.text = "SCORE: " + score; 
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			PlayerPrefs.DeleteAll ();
			score = 0;
		
		}
	
	}


	public void AddScore(int points){
		score += points;
		Debug.Log (score);
	}

	public void OnDestroy(){

		PlayerPrefs.SetInt ("scorePref", score);
		PlayerPrefs.Save ();
	}
		


}
