using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_LaserPointer : MonoBehaviour {

	private Ray ray;
	private RaycastHit hit;

	private Vector3 position;

	private LineRenderer lineRend;

	void Start () {
		lineRend = GetComponent<LineRenderer> ();
	}

	void FixedUpdate () {
		Raycaster ();
	}

	void Raycaster(){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if ( Physics.Raycast (ray, out hit))
			Debug.Log (hit.collider.name); 

		//Show LaserPointer
		lineRend.SetPosition (0, hit.point + Vector3.up * 100f);
		lineRend.SetPosition (1, hit.point);


	}

}
