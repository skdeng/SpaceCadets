using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

	//class fields
	public float fMoveSpeed = 10.0f;
	public int iStamina = 10; 
	public float fMouseSensitivity = 5.0f;
	public float fJumpSpeed = 5.0f;

	private float pitchRange = 60.0f;
	private float pitchRotation = 0;
	private float vertVelocity = 0;
	private float sideSpeed = 0.0f;
	private float forwardSpeed = 0.0f;
	CharacterController characterController;


	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		//controlling player view
		float rotateYaw = Input.GetAxis ("Mouse X") * fMouseSensitivity;
		transform.Rotate (0, rotateYaw, 0);
		pitchRotation -= Input.GetAxis ("Mouse Y") * fMouseSensitivity;
		pitchRotation = Mathf.Clamp (pitchRotation, -pitchRange, pitchRange);
		Camera.main.transform.localRotation = Quaternion.Euler (pitchRotation, 0, 0);

		//user movement
		if (Input.GetButton ("Sprint") && iStamina != 0) {
			sideSpeed = Input.GetAxis ("Horizontal") * fMoveSpeed * 1.5f;
			forwardSpeed = Input.GetAxis ("Vertical") * fMoveSpeed * 1.5f;
			iStamina--;
		} else {
			sideSpeed = Input.GetAxis ("Horizontal") * fMoveSpeed;
			forwardSpeed = Input.GetAxis ("Vertical") * fMoveSpeed;
			if (iStamina < 10) {
				iStamina++;
			}
		}

		//jumping
		if(characterController.isGrounded && Input.GetButtonDown("Jump")){
			vertVelocity = fJumpSpeed;
		}

		//crouching
		if (characterController.isGrounded && Input.GetButton ("Crouch")) {
			characterController.height = 1;
		} else {
			characterController.height = 2;
		}

		//speed and gravity
		vertVelocity += Physics.gravity.y * Time.deltaTime;
		Vector3 aMovement = new Vector3 (sideSpeed, vertVelocity, forwardSpeed);
		aMovement = transform.rotation * aMovement;
		

		characterController.Move(aMovement * Time.deltaTime);
	}
}
