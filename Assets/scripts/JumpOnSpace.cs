using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnSpace : MonoBehaviour {

	public float thrust;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	void Update()
	{
		 if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
			rb.AddRelativeForce(Vector3.up * thrust);
        }
	}
}
