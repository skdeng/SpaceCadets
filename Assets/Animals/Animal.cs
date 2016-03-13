using UnityEngine;
using System.Collections;

//abstract because there is nothing it can really concretely do, and the functions can't be abstract unless the class is
//lifeform is also abstract see: Lifeform
//
public abstract class Animal : Lifeform {
	//public so that it is easily manipulatible with Unity
	public string behaviour;
	public float speed;
	public float strength;

	//common to animals
	abstract void move ();
	abstract void hit(/*Player here*/);
}
