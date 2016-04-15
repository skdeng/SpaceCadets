using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeeleWeapon : Weapon {

	public Animator animator;


	private Sprite weaponSprite, swordMeele, defaultMeele;
	private int hashAttack = Animator.StringToHash("meeleFight");
	private WeaponName curWeapon;
	private float hitDelay = 0.5f; //in seconds

	private GameObject thisGameObj;

	static bool waitActive = false; //so wait function wouldn't be called many times per frame




	//TODO make a enum or something like that otherwise this won't work well...

	void Start(){
		animator = GetComponent<Animator> ();
		enabled = true;
		loadSprites();
		//set the default weapon
		curWeapon = WeaponName.Fist;
		updateWeapon ();
		damage = 12f;
		thisGameObj = GameObject.FindGameObjectWithTag ("MeeleAttack");
		animator.Play ("fistIdle");
		Debug.Log ("Hit Pointsadjkffffffffffffffffffffffffffffffffffffffff"	);
	}

	public override void activate(bool newMode){
		enabled = newMode;
		thisGameObj.SetActive (newMode);
	}

	void Update(){
		
		if(Input.GetButtonDown ("Fire")){
			Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;
			hitAction();

			if (Physics.Raycast (ray, out hitInfo, 1.6f)) {	
				Vector3 hitPoint = hitInfo.point;

				if (hitInfo.transform.gameObject.tag == "Enemy" || hitInfo.transform.gameObject.tag == "Interactable") {
					Interactable aInteractable;
					//GameObject.Find("Inventory").GetComponent<InventoryController>().addItem(hitInfo.transform.gameObject.GetComponent<Item>());
					//hitInfo.transform.gameObject.SetActive(false);
					//TODO decrease the health of the interactable
					aInteractable = hitInfo.transform.gameObject.GetComponent<Interactable> ();
					aInteractable.hit(damage);
				}
			}
		}
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
		waitActive = false;
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

	public override int getID() {
		return 10;
	}
}
