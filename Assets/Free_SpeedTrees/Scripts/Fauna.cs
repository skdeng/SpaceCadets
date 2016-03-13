using UnityEngine;
using System.Collections;

public abstract class Fauna : Lifeform {
	//may not be abstract?... we will see in time
	protected growthFunction growth;
	protected float age;

	public grow(){
		growth.getGrowth(Vector3 curScale);
	}

	public setGrowth(growthFunction newGrowth){
		growth = newGrowth;
	}

	//Item collect(){
	// return itemYielded;
	//}

}
