using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChangeColorOnMouseOver : MonoBehaviour {

	private Color initialColor;
	private Renderer render;

	void Start () {
		render = GetComponent<Renderer> (); 
		initialColor = render.material.color ;
	}
	
	void OnMouseOver () {
		render.material.color = new Color (255, 0, 0);
	}

	void OnMouseExit() {
		render.material.color = initialColor;
	}
}
