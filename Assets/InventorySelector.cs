using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySelector : MonoBehaviour {
	// Use this for initialization
	int pos = 0;
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.O) && pos > 0) {
			Debug.Log ("Left");
			transform.Translate(new Vector3(-58,0,0));
			pos--;
		}
		if (Input.GetKeyDown(KeyCode.P) && pos < 7) {
			Debug.Log ("Right");
			transform.Translate(new Vector3(58,0,0));
			pos++;
		}

	}
}
