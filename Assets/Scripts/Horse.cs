using UnityEngine;
using System.Collections;

public class Horse : Animal {

	// Use this for initialization
	void Start () {
		//for change of state for animations
		anim = GetComponent<Animator> ();
		animalItem = GetComponentInParent<HorseMeatItem>();

		GetComponentInParent<HasHealth> ().setHealth (fMaxHealth);

		terrain = GameObject.Find ("Terrain").GetComponent<Terrain>();
		if (terrain != null) {	
			fLasttime = Time.time;
            transform.position = new Vector3(Random.Range(-450, 450), terrain.SampleHeight(transform.position), Random.Range(-450, 450));
        }
	}

    void Update() {
		updateMethod ();

		startWalking(anim);

		if (Time.time - fLasttime > fIdletime && !bMoving) {
			anim.SetBool("IsWalking", true);
			move();
			fLasttime = Time.time;
		} else if (bMoving) {
			goForward();
			if (Time.time - fLasttime > fWalkingTime) {
				anim.SetBool("IsWalking", false);

				stopWalking(anim);
			}
		}
    }

	//placeholders for now
	override public void move(){
        bStartMoving = true;
        moveVector = randomMove();
        anim.SetBool("IsWalking", true);
	}

	public override void hit(float damage){
		HasHealth aHealth = GetComponentInParent<HasHealth> ();

		aHealth.ReceiveDamage (damage);
	}

	public override void die(){
		Destroy (gameObject);
	}
}
