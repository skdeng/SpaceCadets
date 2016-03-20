using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

	//class fields
	public float moveSpeed = 10.0f;
	public float mouseSensitivity = 5.0f;
	public float pitchRange = 60.0f;
	public float jumpSpeed = 20.0f;
	float pitchRotation = 0;
	float vertVelocity = 0;
	CharacterController characterController;


	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		//controlling player view
		float rotateYaw = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotateYaw, 0);
		pitchRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		pitchRotation = Mathf.Clamp (pitchRotation, -pitchRange, pitchRange);
		Camera.main.transform.localRotation = Quaternion.Euler (pitchRotation, 0, 0);

		//user movement
		float sideSpeed = Input.GetAxis ("Horizontal")* moveSpeed;
		float forwardSpeed = Input.GetAxis("Vertical")* moveSpeed;

		//jumping
		if(characterController.isGrounded && Input.GetButtonDown("Jump")){
			vertVelocity = jumpSpeed;
		}

		//speed and gravity
		vertVelocity += Physics.gravity.y * Time.deltaTime;
		Vector3 aMovement = new Vector3 (sideSpeed, vertVelocity, forwardSpeed);
		aMovement = transform.rotation * aMovement;
		

		characterController.Move(aMovement * Time.deltaTime);
	}
}
