using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleProperty : MonoBehaviour {

	// flag to check if we should grow or shrink the game object
	bool m_isGrowing = true;
	//the value of the original scale of the game object
	Vector3 m_originalScale;
	//the value of the doubled up scale we want to reach
	Vector3 m_desiredScale;
	//the speed on how fast we want to increase the scaling per second
	[SerializeField] float m_scalingSpeed = 100.0f;

	// Use this for initialization
	void Start () {

		//save the original scale value
		m_originalScale = gameObject.transform.localScale;

		//set the desired scale on the double size
		m_desiredScale.x = m_originalScale.x * 2.0f;
		m_desiredScale.y = m_originalScale.y * 2.0f;
		m_desiredScale.z = m_originalScale.z * 2.0f;

	}
	
	// Update is called once per frame
	void Update () {

		//on each frame decide to increas or decrease scale vector
		Vector3 currentScale = gameObject.transform.localScale;

		///if the flag is set on growing increase the scalse vector
		if (m_isGrowing) {
			currentScale.x = currentScale.x + m_scalingSpeed * Time.deltaTime;
			currentScale.y = currentScale.y + m_scalingSpeed * Time.deltaTime;
			currentScale.z = currentScale.z + m_scalingSpeed * Time.deltaTime;

			///if the scale value is bigger, start to shrink in the next frame
			if (currentScale.x > m_desiredScale.x) 
			{
				currentScale = m_desiredScale;
				m_isGrowing = false;
			}

		} else {

			//if the flag is set to shrinking decrease scale vector
			currentScale.x = currentScale.x - m_scalingSpeed * Time.deltaTime;
			currentScale.y = currentScale.y - m_scalingSpeed * Time.deltaTime;
			currentScale.z = currentScale.z - m_scalingSpeed * Time.deltaTime;

			///if the scale vector is smaller then the original, start to grow again in the next frame
			if (currentScale.x < m_originalScale.x) {

				currentScale = m_originalScale;
				m_isGrowing = true;
			}
		}

		///set the scale vector to the game object!
		gameObject.transform.localScale = currentScale;
	}
}
