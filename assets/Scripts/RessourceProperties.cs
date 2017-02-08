using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RessourceProperties : MonoBehaviour {

	public int ressourceAmount;
	private Vector3 size;

	private Text textAmount;  
	public Canvas canvas;  

	void Start () {
		size = transform.localScale;
		ressourceAmount = Mathf.RoundToInt(size.x * 10f); //ressourceAmount abhängig von der größe des objektes
		textAmount = gameObject.AddComponent<Text>();


	}

	void Update(){
		OnDeactivation ();
	}

	void  OnDeactivation(){
		if (!enabled) {
			textAmount.text = "+ " + ressourceAmount.ToString ();
		}
	}
}