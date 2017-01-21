using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager
{
 public List<GameObject> population;
 public Color color;

 public Manager(GameObject self)
 {
  population = new List<GameObject> ();
  population.Add (self);
  color = new Color (Random.Range (0f, 1.0f), Random.Range (0f, 1.0f), Random.Range (0f, 1.0f));
  self.GetComponent<Renderer> ().material.color = this.color;
 }

 public void Add(GameObject other)
 {
    this.population.Add (other);
    other.GetComponent<ObjectControl>().manager = this;
    other.GetComponent<Renderer> ().material.color = this.color;
 }

 public void Merge(Manager other)
 {
  
  foreach(var obj in other.population)
  {
    this.Add(obj);
  }
  other = null;
 }

}


public class ObjectControl : MonoBehaviour
{
 public Manager manager = null;
 // bool first = false;
  
 // Use this for initialization
 void Start ()
 {


  var center = gameObject.transform.position;
  var scale = gameObject.transform.localScale;

  Debug.Assert (scale.x == scale.y && scale.x == scale.z && scale.z == scale.y, "Object scale must be uniform over all dimensions!");

  var collider = gameObject.GetComponent<SphereCollider> ();
  var collider_radius = collider.radius;

  // Found overlap objects
  var hits = Physics.OverlapSphere (center, scale.x * collider_radius);

  var list = FilterByTag (hits, "EnvironmentObject");

  if (list.Count == 1  && list[0] == this.gameObject.GetComponent<Collider>()) {
   // create new manager and add the only object 'itself'
   this.manager = new Manager (this.gameObject);

  } else {
   //get manager and assign self
   var managerList = GetAllManager(list);

   if( managerList.Count > 1)
   {
    Debug.Log("ManagerList " + managerList.Count);
    foreach(var manager in managerList.GetRange(1,managerList.Count-1))
     managerList[0].Merge(manager);

   }

   managerList[0].Add(this.gameObject);

  }

 }

 public List<Collider> FilterByTag (Collider[] objects, string tag)
 {
  var objectList = new List<Collider> ();
  foreach (var obj in  objects) {
   if ((obj.gameObject.tag.CompareTo (tag) == 0))
    objectList.Add (obj);
  }

  return objectList;
 }

 public List<Manager> GetAllManager (List<Collider> objects)
 {
  var set = new HashSet<Manager> ();
  foreach (var obj in  objects) {
   var component = obj.GetComponent<ObjectControl> ();
   if (component != null && component.manager != null)
    set.Add (component.manager);
  }

  return new List<Manager> (set);
 }

}

// public virtual bool ContainsOnlyAndSelf (string tag, Collider[] objects, GameObject self)
// {
//  foreach (var obj in  objects) {
//   if ((obj.gameObject.tag.CompareTo (tag) != 0) && obj.gameObject != self)
//    return false;
//   Debug.Log (obj.gameObject.tag);
//  }
//  return true;
// }
//
// public virtual GameObject GetFirstOccurenceOf(string tag, Collider[] objects)
// {
//  foreach (var obj in  objects) {
//   if ((obj.gameObject.tag.CompareTo (tag) == 0))
//    return obj.gameObject;
//  }
//  return null;
// }
//
// public virtual Manager[] GetManagers(string tag, Collider[] objects)
// {
//  Manager[] managers;
//  foreach (var obj in  objects) {
//   if ((obj.gameObject.tag.CompareTo (tag) == 0) && obj.GetComponent<ObjectControl>().manager != null)
//     obj.GetComponent<ObjectControl>().manager;
//  }
//  return null;
// }
