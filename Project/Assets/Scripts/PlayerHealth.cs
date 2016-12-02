using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	public Stat health;
	//[SerializeField]
	//public float maxValue;


	//[SerializeField]
	//private float currentValue;

	//initialize stat health
	void Awake(){
		health.Initialize ();
	}


	//remove player health function
	public void RemoveHealth(int amount) {
		health.CurrentValue -= amount;

	}

}
