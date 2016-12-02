using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	 public Monster currentMonster;
	 public Stat health;


	public Vector3 TargetPosition;
	public float speed = 25.0f;
	private float timeToDestroy = 1.5f;
	public GameObject explosion;
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, TargetPosition, speed * Time.deltaTime);
		StartCoroutine (destoryProjectile());
	}
		
	void OnCollisionEnter2D(Collision2D col){
		GameObject explode = null;
		if (col.gameObject.name == "Golem" || col.gameObject.name == "Ninja" || col.gameObject.name == "Zombie")
		{
			explode = Instantiate (explosion, transform.position, Quaternion.identity) as GameObject;
			//Debug.Log ("EXPLODE");
			Monster currentMonster;
			//print("Enter");
			currentMonster = col.gameObject.GetComponent<Monster>();
			currentMonster.health.CurrentValue -= 10;
		}

		Destroy (gameObject);
		if (explode) {
			Destroy (explode, 1);
		}
	}


	IEnumerator destoryProjectile(){
		
		yield return new WaitForSeconds (timeToDestroy);
		Destroy (gameObject);
	}
		
}


