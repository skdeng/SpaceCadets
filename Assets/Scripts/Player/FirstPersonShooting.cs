using UnityEngine;
using System.Collections;

//controls 

public class FirstPersonShooting : Weapon {

	//Our projectile (Defaults to plasma)
	public GameObject gProjectile1, gProjectile2, gun;
	private GameObject gProjectile;
	public Mesh mesh1, mesh2;
	private float fProjectileForce = 100f;

	// Use this for initialization
	void Start () {

		if (enabled) {
			gun.GetComponent<Renderer> ().enabled = true;
		} else {
			gun.GetComponent<Renderer> ().enabled = false;
		}

		//thisGameObj = GameObject.FindGameObjectWithTag ("PlasmaGun");
		//gun.GetComponent<MeshFilter>().mesh = Mesh//;
		//gProjectile = gun;
	}

	public void setProjectile(GameObject pProjectile){
		gProjectile = pProjectile;

	}
	
	// Update is called once per frame
	void Update () {
		

	
		if (Input.GetButtonDown ("Fire") && enabled) {
			gun.GetComponent<Renderer> ().enabled = true;
			Camera gameCamera = Camera.main;
			Transform Weapon = gameCamera.transform.GetChild(0);

			//Instantiate the projectile and impart force onto it
			GameObject aProjectile = (GameObject)Instantiate(gProjectile, Weapon.position, gameCamera.transform.rotation);
			aProjectile.GetComponent<Rigidbody>().GetComponent<Rigidbody>().AddForce(gameCamera.transform.forward * fProjectileForce, ForceMode.Impulse);
		}
			
	}

	public override void hitAction(){
		//throw new System.NotImplementedException ();
	}

	public override void changeWeapon (WeaponName wn)
	{
		MeshFilter tempFilter = gun.GetComponent<MeshFilter> ();

		if (wn == WeaponName.Arch) {
			tempFilter.mesh = mesh1;
			gProjectile = gProjectile1;
		} else if (wn == WeaponName.Hell) {
			tempFilter.mesh = mesh2;
			gProjectile = gProjectile1;
			//TODO change the projectile
		}
	}

	public override void activate(bool newMode){
		//GameObject.Destroy (GameObject.FindGameObjectWithTag ("PlasmaGun"));
		Renderer tempRend = gun.GetComponent<Renderer> ();
		enabled = newMode;

		if (enabled) {
			tempRend.enabled = true;
		} else {
			tempRend.enabled = false;
		}

	}

	//TODO chnage weapon, also hitshit which has to be initiatied via fightbehavious. Not this fucker

}
