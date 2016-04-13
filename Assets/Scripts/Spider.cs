using UnityEngine;
using System.Collections;

public class Spider : Animal {


    int idle = Animator.StringToHash("endidle");
    int walk = Animator.StringToHash("walk");
	// Use this for initialization
	int die1 = Animator.StringToHash("dead");

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

	// Update is called once per frame
	void Update () {
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


	override public void move(){
        bStartMoving = true;
        moveVector = randomMove();
        anim.SetBool("IsWalking", true);
	}

	public override void hit(float damage){
	}

	public override void die(){
	}
}
