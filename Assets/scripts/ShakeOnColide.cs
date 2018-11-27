using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnColide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	
	 void OnCollisionEnter(Collision collision)
    {
        //foreach (ContactPoint contact in collision.contacts)
        //{
			Debug.Log("kollision for shake");	
			Shake();
			//Awake();
     //   }
    }
	public Transform camTransform;
	public float shakeDuration = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	Vector3 originalPos;
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Shake()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}
