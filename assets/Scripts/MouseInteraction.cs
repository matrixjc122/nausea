using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInteraction : MonoBehaviour {

	public Text uiStatusLine;
	public GameObject objectToPlace;

	private RaycastHit hit;
	private Vector3 hitPoint;

	private RessourceProperties ressourceProperties; 

	void Raycast()
	{		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					
		Physics.Raycast (ray, out hit);
	}

	void Update () {
		Raycast ();
		CursorInformation ();
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
  		if (hit.collider != null && (hit.collider.CompareTag("EnvironmentGround") || hit.collider.CompareTag("EnvironmentRessource")))
		{
			hitPoint = hit.point;
      		hitPoint.y = 0;
			Debug.Log (hitPoint);
			Instantiate (objectToPlace, hitPoint, Quaternion.identity);
		} 
	}

	void CursorInformation(){



		if (hit.collider != null) 
		{
			uiStatusLine.text = "This objects name is: " + hit.collider.name; 
		}

		if (hit.collider != null && hit.collider.CompareTag("EnvironmentRessource"))
		{
			RessourceProperties otherRessourceProperties = hit.collider.GetComponent<RessourceProperties> ();  
			uiStatusLine.text = hit.collider.name + " --> RessourceAmount: " + otherRessourceProperties.ressourceAmount; 
		}
	}
}


