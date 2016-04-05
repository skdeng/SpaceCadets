using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public UIManager ui;

	// Use this for initialization
	void Start () {
        GameObject.Find("PauseCanvas").GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ui.togglePause();     
        }
	}
}
