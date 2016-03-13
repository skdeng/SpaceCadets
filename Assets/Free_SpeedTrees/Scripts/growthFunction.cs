using UnityEngine;
using System.Collections;

//the interface for growthfunction strategy
interface growthFunction {
	//method common to the strategies
	float getGrowth (Vector3 curScale);

}
