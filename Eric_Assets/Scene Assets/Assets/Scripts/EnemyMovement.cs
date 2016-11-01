using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Animator anim;
	Transform trans;
	GameObject enemy;
	public float Speed;
	SpriteRenderer spriteRender;
	private bool facingRight;
	public float speed = 1f;

	private Transform target; 

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();
		trans = GetComponent<Transform> ();
		enemy = GetComponent<GameObject> ();
		spriteRender = GetComponent<SpriteRenderer> ();

		transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);

	}
	
	// Update is called once per frame
	void Update () {

		//transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);

	//	transform.Translate (0, speed * Time.deltaTime, 0);

	// 	transform.Translate (speed * Time.deltaTime, 0, 0);



		if (Input.GetKey (KeyCode.RightArrow)) {
			anim.SetInteger ("State", 1);
			transform.Translate(new Vector3(0.05f, 0, 0)); 

			if (spriteRender.flipX == true) {
				spriteRender.flipX = false;

			}	
		
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetInteger ("State", 1);
			transform.Translate(new Vector3(-0.05f, 0, 0)); 

			spriteRender.flipX = true;		
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			anim.SetInteger ("State", 0);
			transform.Translate(new Vector3(0, 0.05f, 0)); 
		
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			anim.SetInteger ("State", 0);
			transform.Translate(new Vector3(0, -0.05f, 0)); 

		}


	}

}
