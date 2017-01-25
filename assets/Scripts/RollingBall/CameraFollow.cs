using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	public BallController ballControl;

	private Vector3 offset;
	private Vector3 initialPosition;

	void Start () {
		//ballControl = GetComponent<BallController> ();
		offset = Camera.main.transform.position - transform.position;
	}



	void OnMouseOver() {
		Camera.main.transform.position = transform.position + offset;
	}
}
