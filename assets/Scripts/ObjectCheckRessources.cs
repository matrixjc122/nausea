using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheckRessources : MonoBehaviour {

	public int availableRessources;
	public List<Collider> foundColliders = new List<Collider>();

	// Use this for initialization
	void Start () {
		float radius = gameObject.GetComponent<SphereCollider>().radius;


		Collider[] hit;
		hit = Physics.OverlapSphere(transform.position, radius); 

		for (int i = 0; i < hit.Length; i++) {
			Debug.Log (hit [i].name);
		}
	}
	
	void OnTriggerEnter (Collider other) {
		foundColliders.Add (other);

		Debug.Log (foundColliders);
		
	}
}
