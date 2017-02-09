using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_BallColorChanger : MonoBehaviour {

	private Renderer rend;
	private ParticleSystem particleSys;
	private ParticleSystem.ColorOverLifetimeModule colorModule; 



	void Start () {
		rend = GetComponent<Renderer> ();
		particleSys = GetComponent<ParticleSystem> ();
		colorModule = particleSys.colorOverLifetime;
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("EnvironmentRessource")) 
		{
			Color currentCol = rend.material.color;

			Color otherCol = other.GetComponent<Renderer> ().material.color;
			rend.material.SetColor("_EmissionColor", otherCol *10f);

			colorModule.color = new ParticleSystem.MinMaxGradient(otherCol, new Color(255f, 255f, 255f, 0f)); 
		}
	}

}
