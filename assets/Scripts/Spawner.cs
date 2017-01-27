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
				float scale = Random.Range (1f, 5f);
				float rotate = Random.Range (0f, 270f);

				GameObject obj = Instantiate (objectToInstantiate, hit.point, Quaternion.Euler(0, rotate, 0));

				obj.transform.localScale = new Vector3 (scale, scale, scale); 
			}
		}
	}
}
