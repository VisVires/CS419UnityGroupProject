using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Monster : MonoBehaviour 
{


	public Transform currentEnemy{ get; set; }

	public Stat health;

	private scoreManager score;
	public int points = 10;

	[SerializeField]
	private float speed;
	private float timeToDestroy = 1.5f;
	private Stack<Node> path;
	private Animator myAnimaator;
	public Point GridPosition { get; set; }
	private bool isDead = false;

	private Vector3 destination;

	void Awake() {
		health.Initialize ();
		score = GameObject.FindGameObjectWithTag ("score").GetComponent<scoreManager> ();
	}

	void Start () {
		
	}

	private void Update()
	{

		Move ();
		Physics2D.IgnoreLayerCollision (8, 9);

		if (!isDead) {
			Die ();
		}
	}




	private void Die () {
		if (health.CurrentValue <= 0) {
			myAnimaator.SetTrigger ("isDead");
			isDead = true;

			score.AddScore (points);
			//Debug.Log ("New Score " + score);
			StartCoroutine (destroyMonster());
		}
	}


	IEnumerator destroyMonster(){

		yield return new WaitForSeconds (timeToDestroy);
		Destroy (gameObject);
	}


	public void Spawn(float speedMultiplier)
	{
		transform.position = Completed.BoardManager.Instance.SpawnPortal.transform.position;
		myAnimaator = GetComponent<Animator>();
		SetPath(Completed.BoardManager.Instance.Path);
		this.speed = speed * speedMultiplier;
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

}
