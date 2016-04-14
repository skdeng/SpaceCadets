using UnityEngine;
using System.Collections;

public class MineralItem: Item  {

	// Use this for initialization
	void Start () {
		aPrefab = Resources.Load<GameObject>("RockPrefab");
		setImage ("Rock");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void consume(){
	}

	public override int getID() {
		return 1;
	}
}
