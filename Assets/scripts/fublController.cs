using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fublController : MonoBehaviour {

	public Transform followTarget;
	 // Speed in units per sec.
    public float speed;
	public float jumpThrust;
    public Rigidbody rb;
	public bool followOnStart;
	public bool happy;

	public AudioClip sound1;
    public AudioClip sound2;

    private AudioSource audioSource;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;

	void Start()
    {
        rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter (Collision coll)
    {
        audioSource.pitch = Random.Range (lowPitchRange,highPitchRange);
        audioSource.Play();
        happy = true;
    }

	void Update()
	{
		 if (happy)
        {	// jump
			rb.AddRelativeForce(Vector3.up * jumpThrust);
            happy = false;
        }
		if (followOnStart)
		{
			float step = speed * Time.deltaTime;
 	       transform.position = Vector3.MoveTowards(transform.position, followTarget.position, step);
		}
	}
}
