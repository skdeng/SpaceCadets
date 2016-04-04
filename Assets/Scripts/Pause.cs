using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    private bool bPaused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            bPaused = !bPaused;
            
            Time.timeScale = 1 - Time.timeScale;
            gameObject.GetComponent<FirstPersonController>().enabled = !gameObject.GetComponent<FirstPersonController>().enabled;
        }
	}
}
