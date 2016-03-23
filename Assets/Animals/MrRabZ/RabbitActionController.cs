using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class RabbitActionController : MonoBehaviour {
	

	private Animator animator, animatorFight;
	private CharacterController controller;
	private GameObject imageFist;

	public bool clicked = false;

	private int hashFight = Animator.StringToHash("punch");
	private int hashFightIdle = Animator.StringToHash("idle");

	private int hashHit = Animator.StringToHash("Base Layer.Hit");
	private int hashDead = Animator.StringToHash("Base Layer.Dead");
	private int hashWalk = Animator.StringToHash("Base Layer.Walk");
	private int hashJump = Animator.StringToHash("Base Layer.Jump");
	private int hashPick = Animator.StringToHash("Base Layer.Pick");
	private int hashPunch = Animator.StringToHash("Base Layer.Punch");

	// Use this for initialization
	void Start () {
		
		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();

		imageFist = GameObject.FindGameObjectWithTag ("Punch");
		animatorFight = imageFist.GetComponent<Animator>();

	}

	/*void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, 150, 40), "Punch"))
		{
			animator.Play(hashPunch);
		}

		if (GUI.Button(new Rect(10, 60, 150, 40), "Dead"))
		{
			animator.Play(hashDead);
		}

		if (GUI.Button(new Rect(10, 110, 150, 40), "Pick up"))
		{
			animator.Play(hashPick);
		}

		if (GUI.Button(new Rect(10, 160, 150, 40), "Get Hit"))
		{
			animator.Play(hashHit);
		}

		if (GUI.Button(new Rect(10, 210, 150, 40), "Jump"))
		{
			animator.Play(hashJump);
		}
	}
	
	// Update is called once per frame
	void Update () {

	

		float v  = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		bool move = (v != 0.0f || h != 0.0f);

		animator.speed = move ? 2.0f : 1.0f;


		animator.SetFloat("Speed", move ? 1.0f : 0.0f);


	}
*/

	public void OnMouseDown() {
		Camera camera = Camera.main;
		float dist;
		ScriptName sn = gameObject.GetComponent<ScriptName>()
			


		dist = Vector3.Distance (transform.position, camera.transform.position);

		if (dist <= 3) {
			clicked = !clicked;
			sn.hitSomething();

			animator.Play (hashHit);

			//animatorFight.Play (hashFightIdle);
		}
	}

	void OnAnimatorMove() {


	}
}
