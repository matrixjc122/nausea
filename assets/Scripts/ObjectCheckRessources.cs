using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCheckRessources : MonoBehaviour {

	public Text uiStatusLine;
	public int availableRessources = 0;

	private RessourceProperties ressourceProperties;


	void Start () {
		float radius = gameObject.GetComponent<SphereCollider>().radius;

		Collider[] hit;
		hit = Physics.OverlapSphere(transform.position, radius); 

		for (int i = 0; i < hit.Length; i++) 
		{
			if (hit[i] != null && hit[i].CompareTag("EnvironmentRessource")) {
				RessourceProperties otherRessourceProperties = hit [i].GetComponent<RessourceProperties> ();
				availableRessources += otherRessourceProperties.ressourceAmount;
			}
		}

		uiStatusLine.text = "Es befinden sich " + availableRessources + " Ressourcen im Umkreis.";
	}
}
