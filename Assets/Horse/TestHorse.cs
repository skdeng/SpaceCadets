using UnityEngine;
using System.Collections;

public class TestHorse : MonoBehaviour {

	Animator anim;
	int idleHash = Animator.StringToHash("Horse_Idle");
	int idleWalk = Animator.StringToHash("Horse_Walk");
	int idleRun = Animator.StringToHash("Horse_Run");
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//anim.SetTrigger (idleWalk);
		//anim.Play ("Allosaurus_Run");
		anim.SetBool("IsWalking", true);


	}
}
