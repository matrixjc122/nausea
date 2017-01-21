using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	//Rotations Sensitivitaet
	public float sensX = 100.0f;
	public float sensY = 100.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -45.0f;
	public float maxY = 45.0f;

	//Move Speed
	private float speed = 2.0f;

	//Zoom Speed
	public float zoomSpeed = 1.0f;

	float rotationX = 0.0f;
	float rotationY = 0.0f;


	void Update () 
	{
		//Zoom
		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		transform.Translate (0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

		//Rotate
		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);
		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);


		//Move
		if (Input.GetKey (KeyCode.W)) {
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.position += Vector3.back * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
	}
}
