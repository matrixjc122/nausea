using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour {

	public GameObject objectToPlace;

	private RaycastHit hit;
	private Vector3 hitPoint;

	void Raycast()
	{		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					
		Physics.Raycast (ray, out hit);
	}

	void Update () {
		Raycast ();
		if(Input.GetMouseButtonDown(0))
		{
			PlaceObject();
		}
	}

	void GetHitPoint(){
		if (hit.collider != null)
		{
			hitPoint = hit.point;
			Debug.Log (hitPoint);
		} 
	}

	void PlaceObject()
	{
		if (hit.collider != null && hit.collider.CompareTag("EnvironmentGround"))
		{
			hitPoint = hit.point;
			Debug.Log (hitPoint);
			Instantiate (objectToPlace, hitPoint, Quaternion.identity);
		} 
	}
}
