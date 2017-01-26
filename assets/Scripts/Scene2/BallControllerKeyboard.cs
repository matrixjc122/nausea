using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerKeyboard : MonoBehaviour {

	public float speed;
	public float maxSpeed;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
	
		Vector3 movement = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);

		rb.AddForce (movement);

		if (rb.velocity.magnitude > maxSpeed) 
		{
		rb.velocity = rb.velocity.normalized * maxSpeed;
		}
	}

	void SelectBalltoMove(){
	}
}
