using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_LightFollow : MonoBehaviour {


	public Transform target;
	public Renderer rend;
	public Light lght;

	void Start(){
		
	}

	void Follow () {
		transform.position = target.position;
	}	

	void LightColor(){
		lght.color = rend.material.GetColor("_EmissionColor") /10f;	
		//lght.color = Color.Lerp (lght.color, Color.black, 0.055f * Time.time);
	}

	void FixedUpdate () {
		Follow ();
	}

	void Update(){
		LightColor ();
	}
}
