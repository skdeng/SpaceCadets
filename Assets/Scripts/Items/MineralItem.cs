using UnityEngine;
using System.Collections;

public class MineralItem: Item  {

	// Use this for initialization
	void Start () {
		aPrefab = Resources.Load<GameObject>("RockPrefab");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
