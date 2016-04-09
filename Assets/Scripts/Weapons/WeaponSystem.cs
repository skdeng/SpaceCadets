using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour {

	public GameObject[] aItems;
	private int currentWeapon = 0;

	// Use this for initialization
	void Start () {
		
		GameObject aWeapon = Instantiate (aItems[0]);
		aWeapon.transform.parent = Camera.main.transform;


		Debug.Log ("Player's Parent: " + aWeapon.transform.parent.name);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			changeWeapon(1);
		}
	}

	public void changeWeapon(int num) {
		currentWeapon = num;
		for(int i = 0; i < aItems.Length; i++) {
			if(i == num)
				aItems[i].gameObject.SetActive(true);
			else
				aItems[i].gameObject.SetActive(false);
		}
	}
}
