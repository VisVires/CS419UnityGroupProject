using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private Stat health;

	private SpriteRenderer spriteRenderer;

	private Animator anim;

	private Rigidbody2D myRigidBody;

	private bool facingRight;

	//private bool isDead;


	[SerializeField]
	private float movementSpeed;

	private void Awake(){
		health.Initialize ();
	}

	void Start(){
		//isDead = false;
		facingRight = true;
		myRigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.Q)) {
			health.CurrentValue += 10;
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			health.CurrentValue -= 10;
		}

	
		
	}

	void FixedUpdate(){
		float horizontal = Input.GetAxis ("Horizontal");
		HandleMovement (horizontal);
		Flip (horizontal);
		Die ();
	

	}

	private void HandleMovement(float horizontal) {
		myRigidBody.velocity = new Vector2 (horizontal * movementSpeed, myRigidBody.velocity.y);

		anim.SetFloat ("speed", Mathf.Abs(horizontal));
	}

	private void Flip(float horizontal){

		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {

			spriteRenderer.flipX = true;
		} else {
			spriteRenderer.flipX = false;
		}
	}
		
	private void Die () {
		if (health.CurrentValue <= 0) {
			anim.SetTrigger ("death");
		}
	}


		
}
