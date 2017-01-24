using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollectRessources : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if(other.CompareTag("EnvironmentRessource"))
			other.gameObject.SetActive (false);
	}

}
