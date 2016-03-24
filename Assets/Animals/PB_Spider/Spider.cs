using UnityEngine;
using System.Collections;

public class Spider : Animal {

	Animator anim;
    int idle = Animator.StringToHash("endidle");
    int walk = Animator.StringToHash("walk");
	// Use this for initialization
	int die = Animator.StringToHash("dead");

	void Start () {
		anim = GetComponent<Animator>();
        fLasttime = Time.time;
	}

	// Update is called once per frame
	void Update () {
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

	override public void hit(){
	}
}
