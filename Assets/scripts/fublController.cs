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
	//public bool happy;
	public float jumpThrust;
    public bool bouncing;

    public Rigidbody rb;


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

    //private int interval = 5; 
    //private float nextTime = 0;
 
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
/* 
        if (bouncing)
        {   
            if (Time.time >= nextTime) {
                bounce();
                nextTime += interval; 
            }
        }
	*/
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

    private void bounce(){
        rb.AddRelativeForce(Vector3.up * jumpThrust);
    }

    // todo: if falling down make sound

    // todo: jump / move / bounce

    // ondeath att explosion force that pushed player away

}

