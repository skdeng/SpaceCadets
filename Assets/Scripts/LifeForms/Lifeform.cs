using UnityEngine;
using System.Collections;

//Abstract for all lifeforms which includes, fauna and animals
public abstract class Lifeform : MonoBehaviour {

	//protected so that it is private but also so that the children can inherit the variables
	protected Vector3 position;
	protected HasHealth health;
	//protected Item itemYielded; needs to be connected with other branch on github with items
	//TODO above...
}
