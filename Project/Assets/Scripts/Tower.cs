using UnityEngine;
using System.Collections;
using System.Collections.Generic;        //so we can use lists

public class Tower : MonoBehaviour {

	public Transform currentEnemy{ get; set; }
	public float turnSpeed = 5.0f;
	public float targetRange = 10.0f;
	private List<GameObject> enemysInRange = new List<GameObject>();




	void OnTriggerEnter2D(Collider2D col){
		GameObject currentMonster;
		if (col.gameObject.name == "greenPlane") {
			print("Enter");
			currentEnemy = col.gameObject.transform;
			currentMonster = col.gameObject;
			enemysInRange.Add(currentMonster);
		}
	}


	void OnTriggerExit2D(Collider2D col){
		GameObject currentMonster;
		if (col.gameObject.name == "greenPlane") {
			print("Exit");
			currentEnemy = null;
			currentMonster = col.gameObject;
			enemysInRange.Remove (currentMonster);
		}
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(4, 4, 0);

		if (currentEnemy) {
			Vector3 lookDirection = currentEnemy.transform.position - transform.position;
			float angle = Mathf.Atan2 (lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
			Quaternion targetRotation = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
		}

	}


}
