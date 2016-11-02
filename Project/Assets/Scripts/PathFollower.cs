using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

	public Transform[] path;
	public float speed = 5.0f;
	public float reachDist = 1.0f;
	public int currentPoint = 0;


	void Start() {
		
	}

	void Update() {

		float dist = Vector3.Distance(path[currentPoint].position, transform.position);
		transform.position = Vector3.MoveTowards (transform.position,path[currentPoint].position, Time.deltaTime*speed );

		if (dist <= reachDist) {
			currentPoint++;
		}		
	}
		
}
