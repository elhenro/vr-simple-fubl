using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Valve.VR;
using Valve.VR.InteractionSystem;
//using UnityEngine.Events;

//[RequireComponent(typeof(AudioSource))]
public class fublController : MonoBehaviour {

	public Transform followTarget;
    public float speed;
	public bool follow;

    public Rigidbody rb;

	//public bool happy;
	public float jumpThrust;

    public AudioClip impactSound;
	public AudioClip sound1;
    public AudioClip sound2;

    private AudioSource audioSource;
    private float lowPitchRange = .5F;
    private float highPitchRange = 1.5F;

    public Hand hand;
    private bool pinched = false;
    SteamVR_Input handType;

    private bool madeHappySound = false;
 
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
        audioSource.pitch = Random.Range (lowPitchRange, highPitchRange);
        audioSource.clip = impactSound;
        audioSource.Play();
        madeHappySound = false;
    }

	private void Update()
	{
		if (getPinch())
        {
            follow = !follow; // toggle follow
			rb.AddRelativeForce(Vector3.up * jumpThrust); 	// jump
            if (madeHappySound == false) {
                makeHappySound(); 
            }
        }

		if (follow)
		{
		    float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, followTarget.position, step);
		}
	}

    public void makeHappySound()
    {
        madeHappySound = true;
        audioSource.pitch = Random.Range (lowPitchRange, highPitchRange);
        audioSource.clip = sound1;
        audioSource.Play();
    }

    public bool getPinch()
    {
        return SteamVR_Input._default.inActions.GrabPinch.GetState(hand.handType);
    }

    // todo: if falling down make sound
}

