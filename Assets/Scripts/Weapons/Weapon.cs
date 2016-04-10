using UnityEngine;
using System.Collections;

public abstract class Weapon : Item {

	public bool enabled;

	public enum WeaponName{
		Fist,
		Sword,
		Arch,
		Hell
	};

	public abstract void hitAction ();
	public abstract void activate (bool newMode);
	public abstract void changeWeapon(WeaponName wn);
}
