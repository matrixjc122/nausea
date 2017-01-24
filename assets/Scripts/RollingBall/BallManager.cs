using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	private Rigidbody rb;
	private RessourceProperties ressourcePorperties; 

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
	}

	void Update () {
		ActualRessources ();
	}

	void ActualRessources(){
		AddRessources ();
		SubstractRessources ();
		Debug.Log (actualAmount + rb.name);
	}

	void AddRessources(){
		if (collectedSomething) 
		{
			added = ressourcePorperties.ressourceAmount; // what was added by ressourceProperties  Script attached to ressourceObject
			actualAmount = actualAmount + added;

			collectedSomething = false;

			//Debug.Log("This ball added " + collectedRessources + "ressources");
		}
	}

	void SubstractRessources(){
		if (Input.GetMouseButton (0)) 
		{
			distance = rb.velocity.magnitude * Time.deltaTime;
		
			substracted = distance * 10f;

			actualAmount = actualAmount - substracted;

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