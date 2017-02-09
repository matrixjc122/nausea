using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_BallManager : MonoBehaviour {

	public Text showActualAmount;
	private Rigidbody rb;
	private RessourceProperties ressourcePorperties; 

	public float startAmount;
	private float actualAmount;
	private bool collectedSomething;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		collectedSomething = false;
		actualAmount = startAmount;
	}

	void Update () {
		ActualRessources ();
		Dead ();
	}

	void ActualRessources(){
		AddRessources ();
		SubstractRessources ();
		showActualAmount.text = "Nutrients: " + actualAmount.ToString();
	}

	void AddRessources(){
		if (collectedSomething) 
		{
			float added = ressourcePorperties.ressourceAmount; // what was added by ressourceProperties  Script attached to ressourceObject
			actualAmount = actualAmount + added;

			collectedSomething = false;
		}
	}

	void SubstractRessources(){
			float distance = rb.velocity.magnitude * Time.deltaTime;
			float substracted = distance * 2f;

			actualAmount = actualAmount - substracted;
	}

	void Dead(){
		if (actualAmount <= 0) {
			showActualAmount.text = "You are out of ressources.";
			GetComponent<J_BallMovement> ().enabled = false;  
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