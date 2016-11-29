using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	
	[SerializeField]
	private float cameraSpeed = 0;

	
	// Update is called once per frame
	private void Update () 
	{
		GetInput();
	}


	
	private void GetInput()
	{
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
		}			
	}
}
