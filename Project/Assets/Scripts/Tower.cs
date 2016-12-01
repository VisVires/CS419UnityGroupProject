using UnityEngine;
using System.Collections;
using System.Collections.Generic;        //so we can use lists

public class Tower : MonoBehaviour {

	public Transform currentEnemy{ get; set; }
	public float turnSpeed = 5.0f;
	public float targetRange = 10.0f;
	private List<GameObject> enemysInRange = new List<GameObject>();
	public GameObject missile;
	public float rateOfFire = 0.5f;
	private bool allowShoot = true;



	void OnTriggerEnter2D(Collider2D col){
		GameObject currentMonster;
		if (col.gameObject.name == "Golem" || col.gameObject.name == "Ninja" || col.gameObject.name == "Zombie") {
			//print("Enter");
			currentMonster = col.gameObject;
			if (currentEnemy == null && enemysInRange.Count == 0) {
				currentEnemy = col.gameObject.transform;
			}
			enemysInRange.Add(currentMonster);
		}
	}


	void OnTriggerExit2D(Collider2D col){
		GameObject currentMonster;
		if (col.gameObject.name == "Golem" || col.gameObject.name == "Ninja" || col.gameObject.name == "Zombie") {
			//print("Exit");
			currentMonster = col.gameObject;
			enemysInRange.Remove (currentMonster);
			if (enemysInRange.Count == 0) {
				currentEnemy = null;
			} 
			else {
				currentEnemy = enemysInRange [0].transform;
			}
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
			if (allowShoot) {
				StartCoroutine (fireProjectile ());
			} 
		}
	}

	IEnumerator fireProjectile(){
		allowShoot = false;
		GameObject bullet;
		bullet = (Instantiate (missile, transform.position, transform.rotation)) as GameObject;
		bullet.GetComponent<Projectile> ().TargetPosition = currentEnemy.transform.position;
		yield return new WaitForSeconds (rateOfFire);
		allowShoot = true;
	}


}