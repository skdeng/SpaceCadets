using UnityEngine;
using System.Collections;

public class HorseMeatItem : Item {

	// Use this for initialization
	void Start () {
		aPrefab = Resources.Load<GameObject>("DeadHorseMeats");
		setImage ("meat");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void consume(){
		Player player = GameObject.Find ("Player").GetComponent<Player> ();
		player.setHealth(player.getHealth() + 20);

	}
}
