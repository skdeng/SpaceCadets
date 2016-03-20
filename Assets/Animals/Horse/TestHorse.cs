using UnityEngine;
using System.Collections;

public class TestHorse : Animal {

	Animator anim;

	// Use this for initialization
	void Start () {
		//for change of state for animations
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//enables walking of the horse on the spot
		anim.SetBool("IsWalking", true);

	}

	//placeholders for now
	override public void move(){
	}

	override public void hit(){
	}
}
