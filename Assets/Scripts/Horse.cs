using UnityEngine;
using System.Collections;

public class Horse : Animal {
	bool bRun;
	float fDist;

	// Use this for initialization
	void Start () {
		//for change of state for animations
		anim = GetComponent<Animator> ();
		animalItem = GetComponentInParent<HorseMeatItem>();
        nMaxHealth = 50;

		GetComponentInParent<HasHealth> ().setHealth (nMaxHealth);

		terrain = GameObject.Find ("Terrain").GetComponent<Terrain>();
		if (terrain != null) {	
			fLasttime = Time.time;
            Vector3 p = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
            transform.position = new Vector3(p.x, terrain.SampleHeight(p), p.z);
        }
	}

    void Update() {
		updateMethod ();
		Camera player = Camera.main;
		startWalking(anim);

		if (Time.time - fLasttime > fIdletime && !bMoving && !bRun) {
			anim.SetBool ("IsWalking", true);
			move ();
			fLasttime = Time.time;
		} else if (bMoving && !bRun) {
			goForward ();
			if (Time.time - fLasttime > fWalkingTime) {
				anim.SetBool ("IsWalking", false);

				stopWalking (anim);
			}
		} else if (bRun) {
			fDist = Vector3.Distance (transform.position, player.transform.position);
			if (fDist > 30) {
				anim.SetBool ("IsRunning", false);
				anim.SetBool ("IsWalking", true);
				startWalking (anim);
				bRun = false;

			} else {

				anim.SetBool ("IsRunning", true);
				//startWalking (anim);
				move ();
				goForward ();
			}
		}
    }

	//placeholders for now
	override public void move(){
		Camera player = Camera.main;

		bStartMoving = true;
		if (!bRun) {
			bStartMoving = true;
			moveVector = randomMove ();
			anim.SetBool ("IsWalking", true);
		} else if (bRun) {
			float fX =  player.transform.position.x;
			float fZ =  player.transform.position.z;
			Vector3 v = new Vector3(fX - transform.position.x, 0 , fZ - transform.position.z);
			//v.Normalize();

			moveVector = -1 * v;
			transform.rotation = Quaternion.LookRotation (moveVector) ;
		}
	}

	public override void hit(float damage){
		HasHealth aHealth = GetComponentInParent<HasHealth> ();

		aHealth.ReceiveDamage (damage);

		bRun = true;

	}

	public override void die(){
		Destroy (gameObject);
	}
}
