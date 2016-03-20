﻿using UnityEngine;
using System.Collections;

public class RabbitDie : Animal {

	Animator anim;
	//int idleHash = Animator.StringToHash("idle");
	//int idleWalk = Animator.StringToHash("walk");
	// Use this for initialization
	int die = Animator.StringToHash("dead");
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		//anim.SetTrigger (idleWalk);
		//anim.Play ("Allosaurus_Run");
		anim.SetTrigger(die);


	}

	override public void move(){
	}

	override public void hit(){
	}
}
