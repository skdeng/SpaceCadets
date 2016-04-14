using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeeleWeapon : Weapon {

	public Animator animator;


	private Sprite weaponSprite, swordMeele, defaultMeele;
	private int hashAttack = Animator.StringToHash("meeleFight");
	private double damage;
	private WeaponName curWeapon;
	private float hitDelay = 1.0f; //in seconds

	private GameObject thisGameObj;

	static bool waitActive = false; //so wait function wouldn't be called many times per frame




	//TODO make a enum or something like that otherwise this won't work well...

	void Start(){
		//animator = GetComponent<Animator> ();
		enabled = true;
		loadSprites();
		//set the default weapon
		curWeapon = WeaponName.Fist;
		updateWeapon ();

		thisGameObj = GameObject.FindGameObjectWithTag ("MeeleAttack");
	}

	public override void activate(bool newMode){
		enabled = newMode;
		thisGameObj.SetActive (newMode);
	}

	void Update(){
	}


	private void loadSprites(){
		swordMeele = Resources.Load<Sprite>("sword3");
		defaultMeele = Resources.Load <Sprite>("power_fist");
	}

	private void updateWeapon(){
		if (curWeapon == WeaponName.Fist) {
			changeSprite (defaultMeele);
		}
		else if(curWeapon == WeaponName.Sword){
			changeSprite (swordMeele);
		}
	}

	override public void changeWeapon(WeaponName wn){
		curWeapon = wn;
		updateWeapon ();
	}



	private void changeSprite(Sprite newSprite){
		GetComponent<Image>().sprite = newSprite;
	}

	override public void hitAction() {

		if (!waitActive) {
			animator.SetTrigger (hashAttack);
			StartCoroutine(Wait());   
		}


	}

	IEnumerator Wait(){
		waitActive = true;
		yield return new WaitForSeconds (hitDelay);
		waitActive = false;
	}

	public Sprite getSprite(){
		return weaponSprite;
	}

	public override void consume ()
	{

	}
}
