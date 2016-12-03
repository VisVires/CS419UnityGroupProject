using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{

	[SerializeField]
	private float cameraSpeed = 0;
	public float zoomSize=5;

    private void Start()
    {
        zoomSize += 40;
    }

    // Update is called once per frame
    private void Update () 
		{
			
			if(Input.GetKey(KeyCode.J))
			{
				if(zoomSize>2)
					zoomSize -=1;
			}
			if(Input.GetKey(KeyCode.K))
			{
				if(zoomSize<42)
					zoomSize +=1;
			}
			
			
			if(Input.GetAxis("Mouse ScrollWheel")>0)
			{
				if(zoomSize>2)
					zoomSize -=1;
			}
			if(Input.GetAxis("Mouse ScrollWheel")<0)
			{
				if(zoomSize<42)
					zoomSize +=1;
			}
			GetComponent<Camera> ().orthographicSize=zoomSize;
			
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


	/*[SerializeField]
	private float cameraSpeed = 0;
	
	private float xMax;
	private float yMin;

	
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
		
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, xMax), Mathf.Clamp(transform.position.y, yMin, 0),-10);
		
	}
	
	public void SetLimits(Vector3 maxTile)
	{
		Vector3 wp = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
		
		xMax = maxTile.x - wp.x;
		yMin = maxTile.y - wp.y;
	}*/
}
