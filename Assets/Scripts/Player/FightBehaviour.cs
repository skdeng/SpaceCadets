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
		/*mw = GameObject.FindGameObjectWithTag ("MeeleAttack").GetComponent<MeeleWeapon>();
		curWeapon = mw;
		mw.enabled = true;

*/
		fps = GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonShooting>();
		fps.enabled = true;
		curWeapon = fps;

	}



	void changeWeaponType(Weapon w){
		curWeapon.activate(false);
		curWeapon = w;
		curWeapon.activate(true);
	}

	/*void OnGUI() {

		if (Event.current.Equals (Event.KeyboardEvent ("1"))) {

			changeWeaponType (mw);
			curWeapon.changeWeapon(Weapon.WeaponName.Fist);
		}

		if (Event.current.Equals (Event.KeyboardEvent ("2"))) {
			changeWeaponType(mw);
			curWeapon.changeWeapon (Weapon.WeaponName.Sword);
		}

		if (Event.current.Equals (Event.KeyboardEvent ("3"))) {
			changeWeaponType (fps);	
			curWeapon.changeWeapon (Weapon.WeaponName.Arch);
		}
		if (Event.current.Equals (Event.KeyboardEvent ("4"))) {
			changeWeaponType (fps);	
			curWeapon.changeWeapon (Weapon.WeaponName.Hell);
		}


	}
*/
	public Weapon getWeapon(){
		return curWeapon;
	}

	public void hitSomething(){
		//curWeapon.hitAction ();

	}
}
