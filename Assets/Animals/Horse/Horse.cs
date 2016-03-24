using UnityEngine;
using System.Collections;

public class Horse : Animal {

	Animator anim;

	// Use this for initialization
	void Start () {
		//for change of state for animations
		anim = GetComponent<Animator>();
        fLasttime = Time.time;
	}

    void Update() {
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

	override public void hit(){

	}
}
