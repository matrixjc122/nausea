using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInteraction : MonoBehaviour {
	public Text amount;
	private int selectedRessourceAmount;

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

		if (Input.GetMouseButtonDown (1)) 
		{
			ShowRessourceAmount ();
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

	void ShowRessourceAmount(){
		if (hit.collider != null && hit.collider.CompareTag("EnvironmentRessource")){
			selectedRessourceAmount = hit.collider.GetComponent<RessourceProperties> ().ressourceAmount;
			amount.text = "Ressource: " + selectedRessourceAmount.ToString ();
		}
	}

}
