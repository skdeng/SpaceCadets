using UnityEngine;
using System.Collections;

public class FistItem : Item {

	public Weapon.WeaponName wn = Weapon.WeaponName.Fist;


	// Use this for initialization
	void Start () {
		aPrefab = Resources.Load<GameObject>("RockPrefab");
		setImage ("power_fist");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void consume(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FightBehaviour> ().changeWeapon (wn);
	}

	public override int getID() {
		return 1;
	}
}
