using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_GI : MonoBehaviour {


	public float speedPerlinA;
	public float speedPerlinB;
	public float intensity;


	private Renderer rend;
	private Color eigenColor;

	void Start () {
		rend = GetComponent<Renderer> ();
		eigenColor = rend.material.color;
	}

	void Update () {
		Color final = Color.Lerp(Color.black , eigenColor * 1f,  Mathf.PerlinNoise(speedPerlinA*Time.time,speedPerlinB*Time.time));
		rend.material.SetColor ("_EmissionColor", final);

	}
}


