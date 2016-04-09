using UnityEngine;
using System.Collections;

public class Rabbit : Animal {

    Animator anim;

    // Use this for initialization
    void Start() {
        //for change of state for animations
        anim = GetComponent<Animator>();
        fLasttime = Time.time;
    }

    void Update() {
        startWalking(anim);

        if (Time.time - fLasttime > fIdletime && !bMoving) {
            anim.SetFloat("speed", speed);
            move();
            fLasttime = Time.time;
        } else if (bMoving) {
            goForward();
            if (Time.time - fLasttime > fWalkingTime) {
                anim.SetFloat("speed", 0);
                stopWalking(anim);
            }
        }
    }

    //placeholders for now
    override public void move() {
        bStartMoving = true;
        moveVector = randomMove();
        anim.SetFloat("speed", speed);
    }

    override public void hit() {

    }
}
