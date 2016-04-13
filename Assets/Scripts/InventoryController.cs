using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour {

	List<Item> aInventory;
	private Texture2D image;
	// Use this for initialization
	void Start () {
		aInventory = GameObject.Find("Player").GetComponent<FirstPersonGrab>().aInventory;
	}
	
	// Update is called once per frame
	void Update () {
		if (aInventory != null) {
			foreach (Item item in aInventory) {
				Debug.Log (item.name);
			}
		}
	}

	void OnGUI(){
		for(int i = 0; i< 10; i++){
			GUI.Button (new Rect (Screen.width/2+i*60 - 300,Screen.height*(float)(0.9),50,50), image);
		}
	}
}
