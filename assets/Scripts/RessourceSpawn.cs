using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceSpawn : MonoBehaviour {

	public GameObject ground;
	public GameObject ressourceObject;

	public int count;

	private float groundScale;
	private float randX;
	private float randZ;
	private float randRotation;
	private float randScale;

	void Start () {
		groundScale = ground.transform.localScale.x * 5;
		Debug.Log (groundScale);

		for (int i = 0; i < count; i++) 
		{
			randX = Random.Range (-groundScale, groundScale);
			randZ = Random.Range (-groundScale, groundScale);
			randRotation = Random.Range (-90, 90);
			randScale = Random.Range (0.5f, 2f);

			Vector3 pos = new Vector3 (randX, 0, randZ);
			Vector3 rot = new Vector3 (0, randRotation, 0);

			var spawnedRessourceObject = Instantiate (ressourceObject, pos, Quaternion.Euler(rot));

			spawnedRessourceObject.transform.localScale = new Vector3 (randScale, randScale, randScale); // apply random scale
			spawnedRessourceObject.transform.parent = gameObject.transform; //set parent of spawnedRessourceObject
		}
	}

}
