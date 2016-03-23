using UnityEngine;
using System.Collections;

public class FirstPersonShooting : MonoBehaviour {

	//Our projectile
	public GameObject gPlasma_prefab;
	private float fProjectileForce = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire")) {
			Camera gameCamera = Camera.main;

			//Instantiate the projectile and impart force onto it
			GameObject projectile = (GameObject)Instantiate(gPlasma_prefab, gameCamera.transform.position + gameCamera.transform.forward, gameCamera.transform.rotation);
			projectile.GetComponent<Rigidbody>().GetComponent<Rigidbody>().AddForce(gameCamera.transform.forward * fProjectileForce, ForceMode.Impulse);
		}		
	}
}
