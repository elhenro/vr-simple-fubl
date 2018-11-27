using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lookAtTarget : MonoBehaviour {
	
	public Transform target;
   	public float speed;

    void Update()
    {
        Vector3 targetDir = target.position - transform.position;

        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
		
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);

		//transform.LookAt(Vector3.Slerp(transform.forward, transform.right, speed *Time.deltaTime));
/* 
		Vector3 relativePos = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Inverse(rotation);
*/
    }
}
