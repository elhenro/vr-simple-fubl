using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verkaufsScript : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip sound1;

	void Start ()
	{
		//audioSource = GetComponent<AudioSource>();
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = sound1;

		 //audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(/*Collision collision*/)
	{
		GetComponent<AudioSource> ().Play ();

		/*
		foreach (ContactPoint contact in collision.contacts)
		{
			//Debug.DrawRay(contact.point, contact.normal, Color.white);
		}

		if (collision.relativeVelocity.magnitude > 0.1)
			audioSource.clip = sound1;
			*/
			/* 
		if(collision.gameObject.tag == "Donut")
		{*/
			//audioSource = GetComponent<AudioSource>();
			//audioSource.clip = sound1;
			//audioSource.Play();
		//}
	}
	
	void Update ()
	{	
	}
}
