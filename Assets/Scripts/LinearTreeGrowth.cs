using UnityEngine;
using System.Collections;

//a concrete implementation of a tree growth under growthFunction interface for strategy pattern
public class LinearTreeGrowth : MonoBehaviour, growthFunction {

	public readonly float scaleLimit = 4F;
	private float scaleRate = 0.00075F;

	public void Start(){
		scaleRate = Random.Range (0.00075f, 0.0001f);

	}

	public Vector3 getGrowth(Vector3 curScale){
		if (curScale.x <= scaleLimit) {
			curScale += new Vector3 (scaleRate, scaleRate, scaleRate);
		}

		return curScale;


	}
}
