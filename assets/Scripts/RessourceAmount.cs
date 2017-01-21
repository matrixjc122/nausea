using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceAmount : MonoBehaviour {

	public int sum;
	public int amounts;
	public GameObject[] ressources;



	// Use this for initialization
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F))
		{ 	amounts = 0;
			ressources = GameObject.FindGameObjectsWithTag ("EnvironmentRessource");
			foreach (GameObject ressource in ressources) {
				int r = ressource.GetComponent<RessourceProperties> ().ressourceAmount;
				amounts += r;
			}

			Debug.Log(amounts + " amount");
		}
	}


}
	
	