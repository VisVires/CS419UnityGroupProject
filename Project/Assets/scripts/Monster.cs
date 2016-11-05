using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour 
{
	
	[SerializeField]
	private float speed;
	
	private Stack<Node> path;
	
	public Point GridPosition { get; set; }
	
	private Vector3 destination;
	
	private void Update()
	{
		Move();
		transform.localScale = new Vector3 (5, 5, 5);
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
	}
}
