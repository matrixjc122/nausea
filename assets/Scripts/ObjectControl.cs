using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ObjectControl : MonoBehaviour
{
 // public GameObject managerObject = null;
 // bool first = false;
  
 // Use this for initialization
 void Start ()
 {

  this.gameObject.name = NameGenerator.GenRandomFirstName ();


  var center = gameObject.transform.position;
  var scale = gameObject.transform.localScale;

  Debug.Assert (scale.x == scale.y && scale.x == scale.z && scale.z == scale.y, "Object scale must be uniform over all dimensions!");

  var collider = gameObject.GetComponent<SphereCollider> ();
  var collider_radius = collider.radius;

  // Found overlap objects
  var hits = Physics.OverlapSphere (center, scale.x * collider_radius);
  var list = ToGameObjectList (hits);

  list = FilterByTag (list, "EnvironmentObject");
  list.Remove (this.gameObject);

  if (list.Count == 0) {
   var managerObject = new GameObject ();
   var manager = managerObject.AddComponent<Manager> ();
   manager.Add (this.gameObject);
  } else {

   var managerList = GetManagers (list);
   var first = managerList.First();
   managerList.Remove(first);
   foreach (var obj in managerList) {
    Debug.Log (obj.GetComponent<Manager> ().population.Count);
    first.GetComponent<Manager> ().Merge (obj);
   }

   first.GetComponent<Manager>().Add(this.gameObject);
  }
 }


 public List<GameObject> ToGameObjectList (Collider[] objects)
 {
  var objectList = new List<GameObject> ();
  foreach (var obj in  objects) {
   objectList.Add (obj.gameObject);
  }
  return objectList;
 }

 public List<GameObject> FilterByTag (List<GameObject> objects, string tag)
 {
  var objectList = new List<GameObject> ();
  foreach (var obj in  objects) {
   if ((obj.gameObject.tag.CompareTo (tag) == 0))
    objectList.Add (obj.gameObject);
  }
  return objectList;
 }

 public List<GameObject> GetManagers (List<GameObject> objects)
 {
  var set = new HashSet<GameObject> ();
  foreach (var obj in  objects) {
   var manager = obj.transform.parent.GetComponent<Manager> ();
   if (manager != null)
    set.Add (manager.gameObject);
  }
  var unsorted_list = new List<GameObject> (set);
  var query = unsorted_list.OrderBy (obj => -obj.GetComponent<Manager> ().population.Count);
  return new List<GameObject> (query);
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
