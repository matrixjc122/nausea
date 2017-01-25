using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public int numberOfObjects;
	public GameObject objectToInstantiate;

	private float randomX;
	private float randomZ;
	private Renderer r;

	void Start () {
		r = GetComponent<Renderer> ();


		InstantiateAtPositions ();
	}
	

	void InstantiateAtPositions () {
		RaycastHit hit;

		for ( int i = 0; i < numberOfObjects; i++){
			randomX = Random.Range (r.bounds.min.x, r.bounds.max.x);
			randomZ = Random.Range (r.bounds.min.z, r.bounds.max.z);


			if (Physics.Raycast (new Vector3 (randomX, r.bounds.max.y + 5f, randomZ), -Vector3.up, out hit)) 
			{
				Instantiate (objectToInstantiate, hit.point, Quaternion.LookRotation(hit.normal));
				//Debug.Log (hit.normal);
			}
		}
	}
}
