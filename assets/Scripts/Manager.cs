using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager: MonoBehaviour
{
 public List<GameObject> population;
 public Color color;

 public void Awake ()
 {
  population = new List<GameObject> ();
  gameObject.name = NameGenerator.GenRandomLastName ();
  color = new Color (Random.Range (0f, 1.0f), Random.Range (0f, 1.0f), Random.Range (0f, 1.0f), 0.3f);
//  self.GetComponent<Renderer> ().material.color = this.color;
 }

 public void Add (GameObject environmentObject)
 {
  this.population.Add (environmentObject);
  environmentObject.GetComponent<Renderer> ().material.color = this.color;
//  environmentObject.GetComponent<ObjectControl>().managerObject = this.gameObject;
  environmentObject.transform.parent = this.gameObject.transform;

 }

 public void Merge (GameObject other)
 {
  
  foreach (var obj in other.GetComponent<Manager>().population) {
   this.Add (obj);
  }
//
  GameObject.Destroy (other.gameObject);
 }

}