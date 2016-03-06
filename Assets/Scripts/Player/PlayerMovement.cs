using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float aSpeed = 6f;

	Vector3 aMovement;
	Animator aAnim;
	Rigidbody aPlayerBody;
	int floorMask;
	float camRayLength = 100f;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		aAnim = GetComponent<Animator> ();
		aPlayerBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		float aHoriz = Input.GetAxisRaw ("Horizontal");
		float aVert = Input.GetAxisRaw ("Vertical");

		Move (aHoriz, aVert);
		Turn ();
		Animating (aHoriz, aVert);
	}

	void Move (float pHoriz, float pVert)
	{
		aMovement.Set (pHoriz, 0f, pVert);
		aMovement = aMovement.normalized * aSpeed * Time.deltaTime;
		aPlayerBody.MovePosition (transform.position);
	}

	void Turn ()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
				Vector3 playerToMouse = floorHit.point - transform.position;
				playerToMouse.y = 0f;

				Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
				aPlayerBody.MoveRotation (newRotation);
		}

	}

	void Animating(float pHoriz, float pVert)
	{
		bool walking = (pHoriz != 0f || pVert != 0f);
		aAnim.SetBool ("IsWalking", walking);
	} 
}
