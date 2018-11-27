using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Valve.VR;
using Valve.VR.InteractionSystem;
//using UnityEngine.Events;


public class fublController : MonoBehaviour {

	public Transform followTarget;
    public float speed;
	public bool followOnStart;

    public Rigidbody rb;

	public bool happy;
	public float jumpThrust;

	public AudioClip sound1;
    public AudioClip sound2;

    private AudioSource audioSource;
    private float lowPitchRange = .25F;
    private float highPitchRange = 0.9F;

    public Hand hand;
    private bool pinched = false;
    private bool triggerPressed = false;
    SteamVR_Input handType;
 
	void Start()
    {
        rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

         if ((hand == null) && (GetComponent<Hand>() != null)){
            hand = gameObject.GetComponent<Hand>();
         }
    }

    void OnCollisionEnter (Collision coll)
    {
        audioSource.pitch = Random.Range (lowPitchRange,highPitchRange);
        audioSource.Play();
        happy = true;
    }

	private void Update()
	{
        if (pinched != true){
            pinched = SteamVR_Input._default.inActions.GrabPinch.GetState(hand.handType);
        }

        if (pinched){
            triggerPressed = true;
            print("pressed trigger");
        } else {
            triggerPressed = false;
        }

		if (happy)
        {	// jump
			rb.AddRelativeForce(Vector3.up * jumpThrust);
            happy = false;
        }
		if (followOnStart && !triggerPressed)
		{
			float step = speed * Time.deltaTime;
 	       transform.position = Vector3.MoveTowards(transform.position, followTarget.position, step);
		}
	}

    /* 
    public bool getPinch()
    {
        return SteamVR_Input._default.inActions.GrabPinch.GetState(hand.handType);
    }*/
}

