using UnityEngine;
using System.Collections;

// class for first person attacks using a raycast system,
// instead of physics projectiles

public class FirstPersonAttack : MonoBehaviour {

	public float fCoolDown = 0.2f;
	public GameObject gDebrisPrefab;
	public float fRange = 100.0f;
	private float fCoolDownRemaining = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		fCoolDownRemaining -= Time.deltaTime;

		if(Input.GetButtonDown("Fire") && fCoolDownRemaining <= 0){
			Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;

			if(Physics.Raycast(ray, out hitInfo, fRange)){
				Vector3 hitPoint = hitInfo.point;

			//Debug.Log ("Hit Point:" + hitPoint);

				if(gDebrisPrefab != null) {
					Instantiate (gDebrisPrefab, hitPoint, Quaternion.identity);
				}
			}
		}
	}
}