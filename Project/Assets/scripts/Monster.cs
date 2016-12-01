﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour 
{


	public int score;
	//public Text scoreText;

	[SerializeField]
	private Stat health;

	[SerializeField]
	private float speed;
	private float timeToDestroy = 1.5f;
	private Stack<Node> path;
	//private Rigidbody2D myRigidBody;
	private Animator myAnimaator;
	private bool isDead;
	public Point GridPosition { get; set; }

	private Vector3 destination;

	void Awake() {
		health.Initialize ();
	}

	void Start () {
		//isDead = false;
		//PlayerPrefs.GetInt("scorePref");
		//score = PlayerPrefs.GetInt("scorePref");

		//PlayerPrefs.GetInt("scorePref");
		//score = PlayerPrefs.GetInt("scorePref");
		//myRigidBody = GetComponent<Rigidbody2D> ();
	}

	private void Update()
	{
		
		Move ();
		Physics2D.IgnoreLayerCollision (8, 9);
		//transform.localScale = new Vector3 (4, 4, 0);

		if (Input.GetKeyDown (KeyCode.Z)) {
			health.CurrentValue -= 10;
			Debug.Log ("Current Health is " + health.CurrentValue);

		}

		if (Input.GetKeyDown (KeyCode.X)) {
			health.CurrentValue += 10;
			Debug.Log ("Current Health is " + health.CurrentValue);

		}

		Die ();
		/*
		if (scoreText.name == "scoreText") {
			scoreText.text = "Score: " + score; 
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			PlayerPrefs.DeleteAll ();
			score = 0;

		}
		*/
		//UpdateScore ();

		//AddScore ();*/
	}


	private void Die () {
		if (health.CurrentValue <= 0) {
			myAnimaator.SetTrigger ("isDead");
			isDead = true;
			StartCoroutine (destroyMonster());
		}
	}


	IEnumerator destroyMonster(){

		yield return new WaitForSeconds (timeToDestroy);
		Destroy (gameObject);
	}

	/*
	public void AddScore() {
		if (health.CurrentValue <= 0) {
			score += 10;
		}
		if (health.CurrentValue == 0) {
			health.CurrentValue = 1;
		}
	}

	public void OnDestroy(){

		PlayerPrefs.SetInt ("scorePref", score);
		PlayerPrefs.Save ();
	}
	*/
	public void Spawn()
	{
		transform.position = Completed.BoardManager.Instance.SpawnPortal.transform.position;
		myAnimaator = GetComponent<Animator>();
		SetPath(Completed.BoardManager.Instance.Path);
	}


	private void Move()
	{
		transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

		if (transform.position == destination)
		{
			if (path != null && path.Count > 0)
			{
				Animate(GridPosition, path.Peek().GridPosition);
				GridPosition = path.Peek().GridPosition;
				destination = path.Pop().WorldPosition;
			}
		}
	}

	private void SetPath(Stack<Node> newPath)
	{
		if(newPath != null)
		{
			this.path = newPath;
			Animate(GridPosition, path.Peek().GridPosition);

			GridPosition = path.Peek().GridPosition;

			destination = path.Pop().WorldPosition;
		}
	}

	private void Animate(Point currentPos, Point newPos)
	{
		if (currentPos.y > newPos.y)
		{
			//down
			myAnimaator.SetInteger("horizontal", 0);
			myAnimaator.SetInteger("vertical", 1);
		}
		else if (currentPos.y < newPos.y)
		{
			//up
			myAnimaator.SetInteger("horizontal", 0);
			myAnimaator.SetInteger("vertical", -1);
		}
		if (currentPos.y == newPos.y)
		{
			if (currentPos.x > newPos.x)
			{
				//left
				myAnimaator.SetInteger("horizontal", -1);
				myAnimaator.SetInteger("vertical", 0);
			}

			else if (currentPos.x < newPos.x)
			{
				//right
				myAnimaator.SetInteger("horizontal", 1);
				myAnimaator.SetInteger("vertical", 0);
			}
		}
	}
	/*[SerializeField]
	private float speed;
	
	private Stack<Node> path;
	
	public Point GridPosition { get; set; }
	
	private Vector3 destination;
	
	private void Update()
	{
		Move();
		Physics2D.IgnoreLayerCollision (8, 9);
		transform.localScale = new Vector3 (4, 4, 0);
	}
	
	public void Spawn()
	{
		transform.position = Completed.BoardManager.Instance.SpawnPortal.transform.position;
		
		SetPath(Completed.BoardManager.Instance.Path);
	}
	
	private void Move()
	{
		transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
		
		if (transform.position == destination)
		{
			if (path != null && path.Count > 0)
			{
				GridPosition = path.Peek().GridPosition;
				destination = path.Pop().WorldPosition;
			}
		}
	}
	
	private void SetPath(Stack<Node> newPath)
	{
		if(newPath != null)
		{
			this.path = newPath;
			
			GridPosition = path.Peek().GridPosition;
			
			destination = path.Pop().WorldPosition;
		}
	}*/
}
