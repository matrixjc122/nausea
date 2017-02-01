using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float m_DampTime = 0.2f;
	public float m_ScreenEdgeBuffer = 4f;
	public float m_MinSize;
	public float m_MaxSize;
	public Transform m_Target;
	public Rigidbody m_RigidBody;

	private Camera m_Camera;
	private float m_ZoomSpeed; 
	private Vector3 m_MoveVelocity;
	private Vector3 m_DesiredPosition;

	void Awake(){
		m_Camera = GetComponentInChildren<Camera> ();	
		m_RigidBody = m_Target.GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		Move ();
		Zoom ();
	}

	void Move(){
		FindDesiredPosition ();
		transform.position = Vector3.SmoothDamp (transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
	}

	void FindDesiredPosition(){
		m_DesiredPosition = m_Target.position;
	}

	void Zoom(){
		float desiredSize = FindDesiredSize ();
		m_Camera.orthographicSize = Mathf.SmoothDamp (m_Camera.orthographicSize, desiredSize, ref m_ZoomSpeed, m_DampTime);
	}

	float FindDesiredSize(){
		float size = m_RigidBody.velocity.magnitude;

		if (size < m_MinSize)
			size = m_MinSize;
		if (size > m_MaxSize)
			size = m_MaxSize;

		Debug.Log (size);
		return size;
	}

}
