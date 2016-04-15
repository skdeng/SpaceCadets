using UnityEngine;
using System.Collections;

public class SwordItem : Item {
	public Weapon.WeaponName wn = Weapon.WeaponName.Sword;

	// Use this for initialization
	void Start () {
		aPrefab = Resources.Load<GameObject>("SwordPrefab");
		setImage ("sword3");
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
