using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChangeColorOnMouseOver : MonoBehaviour
{

 private Color initialColor;
 private Renderer render;


	
 void OnMouseOver ()
 {
  initialColor = this.transform.parent.GetComponent<Manager> ().color;
  gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0);
 }

 void OnMouseExit ()
 {
  gameObject.GetComponent<Renderer> ().material.color = initialColor;
 }
}
