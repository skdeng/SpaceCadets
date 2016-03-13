using UnityEngine;
using System.Collections;

public abstract class Fauna : Lifeform {
	//may not be abstract?... we will see in time
	//protected for private access and inheritance
	protected growthFunction growth;


	//called by something executing the strategy
	public void grow(){
		growth.getGrowth(Vector3 curScale);
	}

	//to change the growth strategy
	public void setGrowth(growthFunction newGrowth){
		growth = newGrowth;
	}

	//TODO when we have merged the sections
	//Item collect(){
	// return itemYielded;
	//}

}
