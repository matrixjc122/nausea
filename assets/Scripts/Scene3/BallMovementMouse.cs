using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementMouse : MonoBehaviour {

	Rigidbody m_Rigidbody;
	Vector3 m_ActualPosition;
	Vector3 m_DesiredPosition;
	Vector3 m_NewPosition;

	float m_InputX;
	float m_InputY;

	RaycastHit hit;

	void Awake () {
		m_Rigidbody = GetComponent<Rigidbody> ();
	}
	
	void Start () {
	
	}

	void Update () {
		Raycast (); 
	}

	void FixedUpdate () 
	{
		if (Input.GetMouseButton (0) && hit.collider.CompareTag("EnvironmentGround"))
			MoveToPosition ();
	}

	void Raycast()
	{		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast (ray, out hit);
	}

	void MoveToPosition()
	{
		m_ActualPosition = transform.position;
		m_DesiredPosition = hit.point;
		m_NewPosition = m_DesiredPosition - m_ActualPosition;
		m_Rigidbody.AddForce (m_NewPosition.normalized * 100f); 
	}
}
