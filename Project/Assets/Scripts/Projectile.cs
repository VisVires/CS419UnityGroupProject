using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Vector3 TargetPosition;
	public float speed = 5.0f;
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, TargetPosition, speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("EXPLODE");
		Destroy (gameObject);
	
	}

}


