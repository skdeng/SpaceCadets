using UnityEngine;
using System.Collections;

public class InventorySlot : MonoBehaviour {
    UIManager uiManager;

	// Use this for initialization
	void Start () {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        Debug.Log("asdasdasd");
    }

}
