using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRessourceManager : MonoBehaviour {

	private Rigidbody rb;
	private RessourceProperties ressourcePorperties; 

	private float fac;

	private float useRessourcesForMovement;
	private float collectedRessources;
	private bool collectedSomething;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		collectedSomething = false;
	}

	void Update () {
		ChargedAmount ();
		Discharge ();
		Debug.Log (collectedRessources);
	}

	void FixedUpdate(){
		
	}

	void Discharge (){
		if (rb.velocity.magnitude > 0 && Input.GetMouseButton(0)) 
		{
			useRessourcesForMovement = rb.velocity.magnitude * 1.0f;
			collectedRessources -= useRessourcesForMovement;
		}
	}

	void ChargedAmount(){
		if (collectedSomething) 
		{
			collectedRessources += ressourcePorperties.ressourceAmount;
			//Debug.Log("This ball collected " + collectedRessources + "ressources");

			collectedSomething = false;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("EnvironmentRessource")) 
		{
			ressourcePorperties = other.GetComponent<RessourceProperties> ();
			other.gameObject.SetActive (false);

			collectedSomething = true;
		}
	}
}
