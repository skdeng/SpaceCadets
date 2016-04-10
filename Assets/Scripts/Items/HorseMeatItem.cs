using UnityEngine;
using System.Collections;

public class HorseMeatItem : Item {

	// Use this for initialization
	void Start () {
		aPrefab = Resources.Load<GameObject>("DeadHorseMeats");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
