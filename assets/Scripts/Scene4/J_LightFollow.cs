using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_LightFollow : MonoBehaviour {


	public Transform target;


	void Follow () {
		transform.position = target.position;
	}
	

	void FixedUpdate () {
		Follow ();
	}
}
