using UnityEngine;
using System.Collections;

public class fistPunch : MonoBehaviour {

	private Animator animator;

	private int hashPunch;
	private int hashIdle;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		hashPunch = Animator.StringToHash("punch");
		hashIdle = Animator.StringToHash("idle");

	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public void hitAction() {
		
		animator.Play (hashPunch);


	}




}
