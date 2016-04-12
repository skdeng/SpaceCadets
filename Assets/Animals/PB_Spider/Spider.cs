using UnityEngine;
using System.Collections;

public class Spider : Animal {


    int idle = Animator.StringToHash("endidle");
    int walk = Animator.StringToHash("walk");
	// Use this for initialization
	int die1 = Animator.StringToHash("dead");

	void Start () {
		terrain = GameObject.FindGameObjectWithTag ("Terrain").GetComponent<Terrain>();

		float nX = Random.Range (-450, 450);
		float nZ = Random.Range (-450, 450);
		transform.Translate (new Vector3 (nX, 0, nZ));

		anim = GetComponent<Animator> ();
		fLasttime = Time.time;
		float curheight = transform.position.y;
		float terheight = terrain.SampleHeight (transform.position);
		transform.Translate (new Vector3 (0, terheight - curheight , 0));
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
