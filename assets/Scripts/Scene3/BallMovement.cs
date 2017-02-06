using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

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

		//Debug.Log (m_MoveInputValueHorizontal + " Horizontal Input");
		//Debug.Log (m_MoveInputValueVertical + " Vertical Input");

	}

	private void FixedUpdate(){
		//Move.forward and Turn around movement
		//Move ();	
		//Turn ();

		//AddForce movement
		AddForce ();
	}

	private void Move(){
		Vector3 movementVertical = transform.forward * m_MoveInputValueVertical * m_SpeedVertical * Time.deltaTime;
		m_Rigidbody.MovePosition (m_Rigidbody.position + movementVertical);
	}

	private void Turn(){
		float turn = m_MoveInputValueHorizontal * m_SpeedHorizontal * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
	}

	private void AddForce(){
		
		//Vector3 movement = new Vector3 (m_MoveInputValueHorizontal * m_SpeedHorizontal, 0.0f, m_MoveInputValueVertical * m_SpeedVertical);
		//m_Rigidbody.AddForce (movement);

		Vector3 movement = new Vector3 (m_MoveInputValueHorizontal  * m_SpeedHorizontal, 0.0f, m_MoveInputValueVertical * m_SpeedVertical);
		movement = Quaternion.AngleAxis(45f, Vector3.up) * movement;
		m_Rigidbody.AddForce (movement);

	}
}
