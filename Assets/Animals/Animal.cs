﻿using UnityEngine;
using System.Collections;

//abstract because there is nothing it can really concretely do, and the functions can't be abstract unless the class is
//lifeform is also abstract see: Lifeform
//
public abstract class Animal : Lifeform {
	//public so that it is easily manipulatible with Unity
	public string behaviour;
	public float speed = 0.1f;
	public float strength;

    public float fIdletime = 3;
    public float fWalkingTime = 2;

    protected float fLasttime = 0;
    protected bool bStartMoving = false;
    protected bool bMoving = false;
    protected Vector3 moveVector;

	//common to animals
	public abstract void move ();
	public abstract void hit(/*Player here*/);

    protected Vector3 randomMove(Vector3 facing) {
        float fTurnRate = 0.3f;
        Vector3 up = new Vector3(0, 1, 0);
        Vector3 left = Vector3.Cross(up, facing).normalized;
        float fRandom = Random.Range(-1, 1);
        left *= fTurnRate * fRandom;
        return (facing + left).normalized;
    }

    protected Vector3 randomMove() {
        float fX = Random.Range(-10, 10);
        float fZ = Random.Range(-10, 10);
        Vector3 v = new Vector3(fX, 0, fZ);
        v.Normalize();
        return v;
    }

    protected void goForward() {
        transform.Translate(new Vector3(0, 0, speed));
    }

    protected void startWalking(Animator anim) {
        if (anim.IsInTransition(0) && bStartMoving) {
            bMoving = true;
            bStartMoving = false;
            transform.rotation = Quaternion.LookRotation(moveVector) * transform.rotation;
        }
    }

    protected void stopWalking(Animator anim) {
        if (anim.IsInTransition(0)) {
            bMoving = false;
            fLasttime = Time.time;
        }
    }
}
