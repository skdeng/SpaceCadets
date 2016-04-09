using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDB : MonoBehaviour {
	public List<Item> itemList;
	private Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();

	}

	void OnGUI(){
		for (int i = 0; i < 10; i++) {
			GUI.Label (new Rect (10, 10 + i*20, 200, 50), "Hello");
		}
		print ("Helloworld");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
