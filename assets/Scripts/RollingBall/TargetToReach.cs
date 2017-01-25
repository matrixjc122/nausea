using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetToReach : MonoBehaviour {

	public Text winText; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
	
		if (other.CompareTag("RollingBall")){
			winText.enabled = true;
			winText.text = "You reached the target!";
			gameObject.SetActive (false);
		}
	}
}
