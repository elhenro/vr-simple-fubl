using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	[SerializeField] float m_movementSpeed = 100;
	
	// Update is called once per frame
	void Update () {

		///save the current position of the game object
		Vector3 desiredPosition = gameObject.transform.position;

		///gets the horizontal axes if WASD or Arrow Keys were pressed
		///The value is -1 for left and +1 for right
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		desiredPosition.x = desiredPosition.x + horizontalMovement * m_movementSpeed * Time.deltaTime;
		desiredPosition.z = desiredPosition.z + verticalMovement * m_movementSpeed * Time.deltaTime;

		gameObject.transform.position = desiredPosition;
	}
}
