using UnityEngine;
using System.Collections;

//a concrete implementation of a tree growth under growthFunction interface for strategy pattern
public class treeGrowth : MonoBehaviour, growthFunction {

	public readonly float scaleLimit = 4F;
	public readonly float scaleRate = 0.00001F;


	public Vector3 getGrowth(Vector3 curScale){
		if (curScale.x <= scaleLimit) {
			curScale += new Vector3 (scaleRate, scaleRate, scaleRate);
		}

		return curScale;


	}
}
