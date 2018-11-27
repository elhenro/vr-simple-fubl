using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


using Valve.VR;
using Valve.VR.InteractionSystem;

public class devMenu : MonoBehaviour {

	public Hand hand;
	private bool pinched = false;
	SteamVR_Input handType;

	public bool isTouching = false;
	public float maxDistance = 5;
	
	public bool reloadsScene = false;
	public bool isSpawner = false;

	public GameObject furblo;


    public Rigidbody rb;
	//public Rigidbody cb;
	//public GameObject rightHand;


	void Start () {
		if ((hand == null) && (GetComponent<Hand>() != null)){
            hand = gameObject.GetComponent<Hand>();
         }
		 rb = GetComponent<Rigidbody>();
		 //cb = GetComponent<Rigidbody>();
		// rightHand = GetComponent<GameObject>();
	}
	
	void Update () {
		if (getPinch())
        {
			if (isTouching){
				print("devmenu action");
				if(reloadsScene){
					hardRestartGame();
				} else if ( reloadsScene == false){
					if(isSpawner){
						spawnFurblo();
					}
				}
			} else if (isTouching != true){
				isTouching = checkIfIsTouching();
			}
		}

	}

	public bool getPinch() {
        return SteamVR_Input._default.inActions.GrabPinch.GetState(hand.handType);
    }

	void hardRestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 	}

	public bool checkIfIsTouching() {
		return (Vector3.Distance( hand.transform.position , rb.transform.position) < maxDistance);
	}

	private void spawnFurblo() {
		Instantiate(furblo);
	}
}
