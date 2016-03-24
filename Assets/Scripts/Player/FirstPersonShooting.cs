using UnityEngine;
using System.Collections;

//controls 

public class FirstPersonShooting : MonoBehaviour {

	//Our projectile (Defaults to plasma)
	public GameObject gProjectile;

	private float fProjectileForce = 100f;

	// Use this for initialization
	void Start () {
	}

	public void setProjectile(GameObject pProjectile){
		gProjectile = pProjectile;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown ("Fire")) {
			Camera gameCamera = Camera.main;

			//Instantiate the projectile and impart force onto it
			GameObject aProjectile = (GameObject)Instantiate(gProjectile, gameCamera.transform.position + gameCamera.transform.forward, gameCamera.transform.rotation);
			aProjectile.GetComponent<Rigidbody>().GetComponent<Rigidbody>().AddForce(gameCamera.transform.forward * fProjectileForce, ForceMode.Impulse);
		}
			
	}
}
