using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public static Pause pause;


	GameObject PauseMenu;
	bool paused;

	// Use this for initialization
	void Awake () {
		if (pause == null) {
			DontDestroyOnLoad (gameObject);
			pause = this;
		} else if (pause != this) {
			Destroy (gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		paused = true;
		PauseMenu = GameObject.Find ("PauseMenu");
	}
	
	// Update is called once per frame
	void Update () {



		if (paused) {
			PauseMenu.SetActive (true);
			Time.timeScale = 0;
		} else if (!paused) {

			PauseMenu.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Resume() {

		paused = false;

	}

	public void MainMenu() {
		SceneManager.LoadScene ("MainMenu");
	
	}



	public void Save() {

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/savedData.dat");

		PlayerData data = new PlayerData ();


		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load() {
		if (File.Exists (Application.persistentDataPath + "/savedData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/savedData.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();


		}
	}

	public void Quit() {
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	
	}

}


[Serializable]
class PlayerData {

	public float Health { get; set;}
	public float Experience { get; set; }


}