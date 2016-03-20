using UnityEngine;
using System.Collections;

//the interface for growthfunction strategy
public interface growthFunction {
	//method common to the strategies
	Vector3 getGrowth (Vector3 curScale);

}
