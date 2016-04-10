using UnityEngine;
using System.Collections;

//uses a raycast system to determine player/item interactions in the game world

public class FirstPersonGrab : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hitInfo;

		if(Input.GetButtonDown("Grab")){
			if (Physics.Raycast (ray, out hitInfo, 100.0f)) {			
				if (hitInfo.transform.gameObject.tag == "Item") {
					Inventory aInventory = hitInfo.transform.gameObject.GetComponent<Inventory>();
					aInventory.add (hitInfo.transform.gameObject.GetComponent<Item>() );
				}
			}
		}
	}
}