using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FightBehaviour : MonoBehaviour {
	private Animator animatorFight;
	private GameObject imageFist;

	private CharacterController controller;

	private MeeleWeapon mw;
	private FirstPersonShooting fps;

	private Weapon curWeapon;

	private int hashPunch; 
	// Use this for initialization
	void Start () {
		mw = GameObject.FindGameObjectWithTag ("MeeleAttack").GetComponent<MeeleWeapon>();
		curWeapon = mw;
		mw.enabled = true;
		changeWeaponType (mw);

		fps = GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonShooting>();
		fps.enabled = false;
		//curWeapon = fps;

	}



	void changeWeaponType(Weapon w){
		curWeapon.activate(false);
		curWeapon = w;
		curWeapon.activate(true);
	}

	public void changeWeapon(Weapon.WeaponName newWeapon){

		if (newWeapon == Weapon.WeaponName.Fist) {

			changeWeaponType (mw);
			curWeapon.changeWeapon(Weapon.WeaponName.Fist);
		}

		if (newWeapon == Weapon.WeaponName.Sword) {
			changeWeaponType(mw);
			curWeapon.changeWeapon (Weapon.WeaponName.Sword);
		}

		if (newWeapon == Weapon.WeaponName.Arch) {
			changeWeaponType (fps);	
			curWeapon.changeWeapon (Weapon.WeaponName.Arch);
		}
		if (newWeapon == Weapon.WeaponName.Hell) {
			changeWeaponType (fps);	
			curWeapon.changeWeapon (Weapon.WeaponName.Hell);
		}


	}

	public Weapon getWeapon(){
		return curWeapon;
	}

	public void hitSomething(){
		//curWeapon.hitAction ();

	}
}
