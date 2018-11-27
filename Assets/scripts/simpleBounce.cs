using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleBounce : MonoBehaviour {

	//public bool bouncing;
    //public Rigidbody rb;
	//public float power;

    //public int interval = 5; 
    //private float nextTime = 0;
     
/*
	void Update () {
		*//* 
		if(bouncing){
			bounce();
		} *//*
		if (bouncing == true && Time.time >= nextTime) {
			bounce();
			nextTime += interval; 
		}
	}*/

	/*
	private void bounce(){
        rb.AddRelativeForce(Vector3.up * power);
	}*/

	public Vector3 jump;
	public float jumpForce = 2.0f;

	public bool isGrounded;
	public Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
	}

	void OnCollisionStay()
	{
		isGrounded = true;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			isGrounded = false;
		}
		if(isGrounded){
			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			isGrounded = false;
		}
	}
}
