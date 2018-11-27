using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalMovementController : MonoBehaviour {

	[SerializeField] float m_movementSpeed = 100f;

	Rigidbody m_myRigidBody;

	void Start () {
	
		///gets the rigid body component from the current game object
		m_myRigidBody = gameObject.GetComponent<Rigidbody> ();	

		if (m_myRigidBody == null) {

			Debug.Log ("No RigidBody found in PhysicalMovementController");
		}
	}

	// Update is called once per frame
	void Update () {
		
		///gets the horizontal axes if WASD or Arrow Keys were pressed
		///The value is -1 for left and +1 for right
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement 	 = Input.GetAxis ("Vertical");
	
		///we creating a direction vector for the force
		Vector3 movementForce = new Vector3();

		movementForce.x = horizontalMovement * m_movementSpeed * Time.deltaTime;
		movementForce.z = verticalMovement   * m_movementSpeed * Time.deltaTime;
			
		///and add the force as an impulse to the rigid body
		m_myRigidBody.AddForce (movementForce,ForceMode.Impulse); 
	}



}
