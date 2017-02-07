using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_BallMovement : MonoBehaviour {

	public Transform camRot; 
	public Quaternion syncCameraToMove;

	public float m_SpeedHorizontal = 10f;
	public float m_SpeedVertical = 10f;

	public Rigidbody m_Rigidbody;

	private string m_MoveAxisNameHorizontal;
	private string m_MoveAxisNameVertical;
	private float m_MoveInputValueHorizontal;
	private float m_MoveInputValueVertical;


	private void OnAwake(){
		m_Rigidbody = GetComponent<Rigidbody> ();
	}

	private void OnEnable(){
		m_Rigidbody.isKinematic = false;
		m_MoveInputValueHorizontal = 0f;
		m_MoveInputValueVertical = 0f;
	}

	private void OnDisable(){
		m_Rigidbody.isKinematic = true;
	}

	private void Start () {
		m_MoveAxisNameHorizontal = "Horizontal";
		m_MoveAxisNameVertical = "Vertical";
	}
	
	private void Update () {
		m_MoveInputValueHorizontal = Input.GetAxis (m_MoveAxisNameHorizontal);
		m_MoveInputValueVertical = Input.GetAxis (m_MoveAxisNameVertical);

		Debug.Log (camRot.eulerAngles);
	}

	private void FixedUpdate(){
		AddForce ();
	}


	private void AddForce(){
		Vector3 movement = new Vector3 (m_MoveInputValueHorizontal  * m_SpeedHorizontal, 0.0f, m_MoveInputValueVertical * m_SpeedVertical);
		movement = Quaternion.AngleAxis( camRot.eulerAngles.y  , Vector3.up) * movement;
		m_Rigidbody.AddForce (movement);

	}
}
