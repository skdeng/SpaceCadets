using UnityEngine;
using System.Collections;

public class MineralItem: Item  {

    GameManager gameManager;
	// Use this for initialization
	void Start () {
		aPrefab = Resources.Load<GameObject>("RockPrefab");
		setImage ("Rock");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void consume(){
        gameManager.applyPart();
	}

	public override int getID() {
		return 1;
	}
}
