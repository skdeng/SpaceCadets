using UnityEngine;
using System.Collections;

public abstract class Animal : Lifeform {
	//may not be abstract?...
	public string behaviour;
	public float speed;
	public float strength;

	abstract void move ();
	abstract void hit(/*Player here*/);
}
