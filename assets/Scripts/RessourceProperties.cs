using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RessourceProperties : MonoBehaviour {

	public int ressourceAmount;

	private Vector3 size;

	void Start () {
		size = transform.localScale;
		ressourceAmount = Mathf.RoundToInt(size.x * 100f); //ressourceAmount abhängig von der größe des objektes

	}
}