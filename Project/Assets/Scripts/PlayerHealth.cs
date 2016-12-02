using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	public Stat health;

	void Awake(){
		health.Initialize ();
	}

	public void RemoveHealth(int amount) {
		health.CurrentValue -= amount;

	}

}
