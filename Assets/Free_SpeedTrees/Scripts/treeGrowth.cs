using UnityEngine;
using System.Collections;

public class treeGrowth : MonoBehaviour, growthFunction {

	void Start(){

	}


	// Update is called once per frame
	void Update () {
		Vector3 curSize = transform.localScale;
		if (curSize.x <= 4) {
			transform.localScale += new Vector3 (0.00001F, 0.00001F, 0.00001F);

		}

	}

	public float getGrowth(float curAge){
		return 0.1F;
	}
}
