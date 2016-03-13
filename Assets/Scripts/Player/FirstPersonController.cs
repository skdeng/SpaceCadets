using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float moveSpeed = 10.0f;
	public float mouseSensitivity = 5.0f;
	float pitchRotation = 0;
	public float pitchRange = 60.0f;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {

		//controlling player view
		float rotateYaw = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotateYaw, 0);
		pitchRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		pitchRotation = Mathf.Clamp (pitchRotation, -pitchRange, pitchRange);
		Camera.main.transform.localRotation = Quaternion.Euler (pitchRotation, 0, 0);

		//user movement input
		float sideSpeed = Input.GetAxis ("Horizontal")* moveSpeed;
		float forwardSpeed = Input.GetAxisRaw ("Vertical")* moveSpeed;

		//speed
		Vector3 aMovement = new Vector3 (sideSpeed, 0, forwardSpeed);
		aMovement = transform.rotation * aMovement;

		CharacterController cc = GetComponent<CharacterController> ();
		cc.SimpleMove(aMovement);
	}
}
