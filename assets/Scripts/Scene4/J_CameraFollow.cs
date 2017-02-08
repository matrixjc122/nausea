using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_CameraFollow : MonoBehaviour {
	
	public Transform cam;
	public Transform target;

	public float smoothTime;
	private Vector3 followPos;
	private Vector3 velocity = Vector3.zero;

	public float rotationSpeed;

	public float zoomSpeed;
	public float minZoom;
	public float maxZoom;

	void FixedUpdate () 
	{
		Follower ();
		Rotator ();
		Zoomer ();
	}

	void Follower()
	{
		followPos = new Vector3 (target.position.x, transform.position.y, target.position.z);
		transform.position = Vector3.SmoothDamp (transform.position, followPos, ref velocity, smoothTime);
		transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z);
	}

	void Rotator()
	{
		float rotationInput = Input.GetAxis ("Mouse X");
		cam.RotateAround (transform.position, Vector3.up, rotationInput * rotationSpeed); 
	}

	void Zoomer()
	{
		float zoomInput = Input.GetAxis ("Mouse Y")*zoomSpeed;
		cam.position += new Vector3 (0f, zoomInput, 0f);
		cam.LookAt(target);
	}

}
