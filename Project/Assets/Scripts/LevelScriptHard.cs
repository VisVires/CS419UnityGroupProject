using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScriptHard : MonoBehaviour {

	[SerializeField]
	private Text levelText; 

	private bool ShowLevel = false;

	int level;

	// Use this for initialization
	void Start () {
		level = SceneManager.GetActiveScene().buildIndex + 1;
		level = level - 8;
		levelText.text = "LEVEL " + level;
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine (DisplayLevelNumber ());
		if (ShowLevel) {
			Destroy (gameObject);
		}
	}


	private IEnumerator DisplayLevelNumber(){

		yield return new WaitForSeconds (2.0f);

		ShowLevel = true;
	}
}
