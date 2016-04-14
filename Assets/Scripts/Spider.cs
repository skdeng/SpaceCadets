using UnityEngine;
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
    GameObject aPlayer;

	void Start () {
        nMaxHealth = 80;
        nStrength = 20;

        animalItem = GetComponentInParent<HorseMeatItem>();

        aPlayer = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        GetComponentInParent<HasHealth>().setHealth(nMaxHealth);

        terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        if (terrain != null) {
            fLasttime = Time.time;
            Vector3 p = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
            transform.position = new Vector3(p.x, terrain.SampleHeight(p), p.z);
        }
	}

	void Update () {
		Camera playerCamera = Camera.main;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

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
				fDist = Vector3.Distance (transform.position, playerCamera.transform.position);
				if (fDist < 5) {
					anim.SetBool ("IsWalking", false);
					float fX =  playerCamera.transform.position.x;
					float fZ =  playerCamera.transform.position.z;
					Vector3 v = new Vector3(fX - transform.position.x, 0 , fZ - transform.position.z);
					//v.Normalize();

					moveVector = v;
					transform.rotation = Quaternion.LookRotation (moveVector) ;
					if (Time.time - fLasttime > 2.4f) {
                        player.GetComponent<Player>().damage(nStrength);    //TODO this is not working
						fLasttime = Time.time;
					}

					anim.SetTrigger ("hit");

					bHitMode = true; //??
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
            speed = 0.25f;
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
