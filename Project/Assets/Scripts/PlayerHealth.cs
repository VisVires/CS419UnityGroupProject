using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	private Stat health;
	//[SerializeField]
	//public float maxValue;


	[SerializeField]
	private Text healthText;

	//initialize stat health
	void Awake(){
		health.Initialize ();
	}

	void Update(){

		if (healthText.name == "healthText") {
			healthText.text = "HEALTH:  " + health.CurrentValue; 
		}
	}


	//remove player health function
	public void RemoveHealth(int amount) {
		health.CurrentValue -= amount;

	}

}
