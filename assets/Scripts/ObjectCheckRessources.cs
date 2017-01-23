using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheckRessources : MonoBehaviour {

	public int availableRessources = 0;

	private List<Collider> foundColliders = new List<Collider>();
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

		Debug.Log ("Es befinden sich " + availableRessources + " Ressourcen im Umkreis.");
	}
}
