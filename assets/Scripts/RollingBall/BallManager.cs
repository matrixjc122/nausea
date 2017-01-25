using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour {

	public Text showActualAmount;

	private Rigidbody rb;
	private RessourceProperties ressourcePorperties; 
	private BallController ballControl; 

	public float startAmount;
	public float actualAmount;
	public float added;
	public float substracted;
	public float distance;

	private float useRessourcesForMovement;
	private float collectedRessources;
	private bool collectedSomething;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		collectedSomething = false;
		actualAmount = startAmount;
	}

	void Update () {
		ActualRessources ();
		if (actualAmount <= 0)
			Dead ();
	}

	void ActualRessources(){
		AddRessources ();
		SubstractRessources ();
		showActualAmount.text = actualAmount.ToString();
	}

	void AddRessources(){
		if (collectedSomething) 
		{
			added = ressourcePorperties.ressourceAmount; // what was added by ressourceProperties  Script attached to ressourceObject
			actualAmount = actualAmount + added;

			collectedSomething = false;
		}
	}

	void SubstractRessources(){
			distance = rb.velocity.magnitude * Time.deltaTime;
			substracted = distance * 2f;

			actualAmount = actualAmount - substracted;
	}

	void Dead(){
			showActualAmount.text = "You are out of ressources.";
			GetComponent<BallController>().enabled = false;  
	
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