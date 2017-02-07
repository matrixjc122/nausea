using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_CameraFollow : MonoBehaviour {


	public Transform cam;
	public Transform target;

	public float smoothTime;
	public float rotationSpeed;

	private Vector3 velocity = Vector3.zero;
	private Vector3 goalPos;


	void Start () {

	}

	void FixedUpdate () {
		goalPos = new Vector3 (target.position.x, transform.position.y, target.position.z);

		transform.position = Vector3.SmoothDamp (transform.position, goalPos, ref velocity, smoothTime);
		transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z);
		Rotator ();
	}

	void Rotator(){

		float rotationInput = Input.GetAxis ("Mouse X");

		cam.RotateAround (transform.position, Vector3.up, rotationInput * rotationSpeed); 
	}

}
