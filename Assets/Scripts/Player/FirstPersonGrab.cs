using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//uses a raycast system to determine player/item interactions in the game world

public class FirstPersonGrab : MonoBehaviour {

	public List<Item> aInventory;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire")){
			Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;

			if (Physics.Raycast (ray, out hitInfo, 100.0f)) {	
				Vector3 hitPoint = hitInfo.point;
				Debug.Log ("Hit Point:" + hitPoint);


				if (hitInfo.transform.gameObject.tag == "Item") {
					aInventory.Add (hitInfo.transform.gameObject.GetComponent<Item>() );
					Destroy (hitInfo.transform.gameObject);
				}
			}
		}
	}

}