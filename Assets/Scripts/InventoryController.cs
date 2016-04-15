using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour {
	int numItems;
	Item[] aInventory = new Item[9];
	// Use this for initialization
	void Start () {
		numItems = 0;
		aInventory = new Item[9];
		for (int i = 0; i< aInventory.Length; i++) {
			aInventory[i] = null;
		}
		addItem (GameObject.FindGameObjectWithTag ("Player").GetComponent<FistItem> ());
		addItem (GameObject.FindGameObjectWithTag ("Player").GetComponent<GunItem> ());
		//aInventory = GameObject.Find("Player").GetComponent<FirstPersonGrab>().aInventory;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if(aInventory[0]!= null){
				aInventory[0].consume();
				//aInventory[0] = null;
				//numItems--;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if(aInventory[1]!= null){
				aInventory[1].consume();
				//aInventory[1] = null;
				//numItems--;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if(aInventory[2]!= null){
				aInventory[2].consume();
				aInventory[2] = null;
				numItems--;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			if(aInventory[3]!= null){
				aInventory[3].consume();
				aInventory[3] = null;
				numItems--;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			if(aInventory[4]!= null){
				aInventory[4].consume();
				aInventory[4] = null;
				numItems--;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			if(aInventory[5]!= null){
				aInventory[5].consume();
				aInventory[5] = null;
				numItems--;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			if(aInventory[6]!= null){
				aInventory[6].consume();
				aInventory[6] = null;
				numItems--;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			if(aInventory[7]!= null){
				aInventory[7].consume();
				aInventory[7] = null;
				numItems--;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			if(aInventory[8]!= null){
				aInventory[8].consume();
				aInventory[8] = null;
				numItems--;
			}
		}
		
	}
	
	void OnGUI(){
		Texture2D image;
//		for(int i = 0; i< aInventory.Count; i++){
//			//Debug.Log(aInventory[i].getImage());
//		}
		for(int i = 0; i< 9; i++){
			if(aInventory[i]!=null)
			{
				image = Resources.Load<Texture2D>(aInventory[i].getImage());
				GUI.Button (new Rect (Screen.width/2+i*60 - 300,Screen.height*(float)(0.9),50,50), image);
			}
			else{
				image = Resources.Load<Texture2D>("Empty");
				GUI.Button (new Rect (Screen.width/2+i*60 - 300,Screen.height*(float)(0.9),50,50), image);
			}
		}

	}

    public string getItem(int index) {
        if (aInventory[index] == null)
            return "";
        else
            return aInventory[index].getID().ToString();
    }

	public void addItem(Item hit){
		if (numItems < 9) {
			numItems++;
			int firstEmpty = firstEmptySlot();
			aInventory[firstEmpty] = hit;
		}
		for (int i = 0; i < 9; i++) {
			if (aInventory [i] != null) {
				Debug.Log(aInventory[i].getImage());
			}
		}

	}
	int firstEmptySlot(){
		for (int i = 0; i< 9; i++) {
		if(aInventory[i] == null)
				return i;
		}
		return 0;
	}
}
