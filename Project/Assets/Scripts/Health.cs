using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField]
	private Stat health;



	public void RemoveHealth(float amount) {

		health.CurrentValue -= amount;

		if (health.CurrentValue <= 0) {
			Destroy(gameObject);
		}
	}
}
