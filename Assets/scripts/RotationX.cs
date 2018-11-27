using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationX : MonoBehaviour {

	/// <summary>
	/// how fast the gameobject will rotate around its axis
	/// </summary>
	[SerializeField] float m_rotationSpeed = 100.0f;

	Vector3 m_eulerAngles;

	// The start function is triggerd once when the object is created
	void Start () {

		///save the angles of the current object in a variable
		m_eulerAngles = gameObject.transform.rotation.eulerAngles;
	}

	// Update is called once per frame
	void Update () {

		///add a frame independent speed value to the current Y angle
		m_eulerAngles.x = m_eulerAngles.x + m_rotationSpeed * Time.deltaTime;

		gameObject.transform.rotation = Quaternion.Euler (m_eulerAngles);
	}
}
