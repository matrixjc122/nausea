using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float speed;
	public float maxSpeed;

	private Rigidbody rb;
	private bool mouseOver;


	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		mouseOver = false;
	}	
		
	void FixedUpdate () 
	{
		if (mouseOver) {
			float moveHorizontal = Input.GetAxis ("Mouse X");
			float moveVertical = Input.GetAxis ("Mouse Y");
		

		Vector3 movement = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);

		rb.AddForce (movement);
		}

		if (rb.velocity.magnitude > maxSpeed) 
		{
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
	}

	void OnMouseDrag(){
		mouseOver = true;
	}

	void OnMouseUp(){
		mouseOver = false;
	}
}
