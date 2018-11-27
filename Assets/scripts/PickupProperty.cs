using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupProperty : MonoBehaviour {

	AudioSource m_pickupSound;

	void Start()
	{
		m_pickupSound = Camera.main.gameObject.GetComponent<AudioSource> ();

		if (m_pickupSound == null) { Debug.Log ("No AudioSource found in PickupProperty");  }
	}


	void OnCollisionEnter(Collision collision)
	{
		m_pickupSound.Play ();
		Destroy (gameObject);
	}
}
