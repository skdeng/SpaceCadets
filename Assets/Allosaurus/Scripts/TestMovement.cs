using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour {

	Animator anim;
	int idleHash = Animator.StringToHash("Allosaurus_Idle");
	int idleWalk = Animator.StringToHash("Allosaurus_Walk");
	int idleRun = Animator.StringToHash("Allosaurus_Run");
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//anim.Play ("Allosaurus_Run");
		anim.SetBool("IsWalking", true);

	}
}
