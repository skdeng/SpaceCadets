﻿using UnityEngine;
using System.Collections;

public class Spider : Animal {


    int idle = Animator.StringToHash("endidle");
    int walk = Animator.StringToHash("walk");
	// Use this for initialization
	int die1 = Animator.StringToHash("dead");
	protected bool bFightMode = false;
	bool bEnd = false;
	bool bHitMode = false;
	float fDist;

	void Start () {
        anim = GetComponent<Animator>();
        GetComponentInParent<HasHealth>().setHealth(fMaxHealth);

        terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        if (terrain != null) {
            fLasttime = Time.time;
            Vector3 p = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
            transform.position = new Vector3(p.x, terrain.SampleHeight(p), p.z);
        }
	}

	void Update () {
		Camera player = Camera.main;

		startWalking(anim);
		if (!bEnd) {
			if (Time.time - fLasttime > fIdletime && !bMoving && !bFightMode) {
				anim.SetBool ("IsWalking", true);
				move ();
				fLasttime = Time.time;
			} else if (bMoving && !bFightMode) {
				goForward ();
				if (Time.time - fLasttime > fWalkingTime) {
					anim.SetBool ("IsWalking", false);
					stopWalking (anim);
				}
			} else if (bFightMode) {
				fDist = Vector3.Distance (transform.position, player.transform.position);
				GameObject aPlayer = GameObject.FindGameObjectWithTag ("Player");
				//Debug.Log ("antyyysdfhljsdfj'hkjhksdf'jksd'fhsjk");
				if (fDist < 5) {
					anim.SetBool ("IsWalking", false);
					float fX =  player.transform.position.x;
					float fZ =  player.transform.position.z;
					Vector3 v = new Vector3(fX - transform.position.x, 0 , fZ - transform.position.z);
					//v.Normalize();

					moveVector = v;
					transform.rotation = Quaternion.LookRotation (moveVector) ;
					if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
						//player.GetComponent<HasHealth> ().ReceiveDamage (fStrength);
						//Decrease health opf player
					}

					anim.SetTrigger ("hit");

					bHitMode = true;
				} else {
					anim.SetBool ("IsWalking", true);
					startWalking (anim);
					move ();
					goForward ();
				}
			}
		} else if(Time.time - fLasttime > 3){
			Destroy (gameObject);
		}
	}


	override public void move(){
		Camera player = Camera.main;

		bStartMoving = true;
		if (!bFightMode) {
			moveVector = randomMove ();
		} else if(bFightMode){

			float fX =  player.transform.position.x;
			float fZ =  player.transform.position.z;
			Vector3 v = new Vector3(fX - transform.position.x, 0 , fZ - transform.position.z);
			//v.Normalize();

			moveVector = v;
			transform.rotation = Quaternion.LookRotation (moveVector) ;//Quaternion.RotateTowards(transform.rotation, player.transform.rotation, 2.0f * Time.deltaTime);
		}
		anim.SetBool("IsWalking", true);
	}

	public override void hit(float damage){

		HasHealth aHealth = GetComponentInParent<HasHealth> ();

		if(!bEnd){
			aHealth.ReceiveDamage (damage);

			bFightMode = true;

			bStartMoving = true;
			//anim.SetBool("IsWalking", true);
			startWalking (anim);
			move ();
			//goForward ();
		}


	}

	public override void die(){
		bFightMode = false;
		bStartMoving = false;
		anim.SetBool("IsWalking", false);
		stopWalking(anim);

		bEnd = true;
		fLasttime = Time.time;
		anim.SetTrigger ("dead");


		//Destroy (gameObject);
	}
}
