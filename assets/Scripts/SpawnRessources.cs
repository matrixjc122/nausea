using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRessources : MonoBehaviour {

	public GameObject ground;
	public GameObject ressourceObject;

	public int count;

	private float groundScale;
	private float randX;
	private float randZ;
	private float randScale;

	void Start () {
		groundScale = ground.transform.localScale.x * 3;
		Debug.Log (groundScale);

		for (int i = 0; i < count; i++) {
			randX = Random.Range (-groundScale, groundScale);
			randZ = Random.Range (-groundScale, groundScale);
			randScale = Random.Range (0.5f, 2f);

			Vector3 pos = new Vector3 (randX, 0, randZ);

			var spawnedRessourceObject = Instantiate (ressourceObject, pos, Quaternion.identity);
			spawnedRessourceObject.transform.localScale = new Vector3 (randScale, randScale, randScale);
			spawnedRessourceObject.transform.parent = gameObject.transform; //set parent of spawnedRessourceObject
		}


	}

}
