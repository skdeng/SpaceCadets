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

            if (bPaused) {
                Cursor.lockState = CursorLockMode.None;
                AudioListener.pause = true;
                Cursor.visible = true;
                //bring up pause screen
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                AudioListener.pause = false;
                Cursor.visible = false;
                //dismiss pause screen
            }

            Time.timeScale = 1 - Time.timeScale;
            gameObject.GetComponent<FirstPersonController>().enabled = !bPaused;
            gameObject.GetComponent<FirstPersonShooting>().enabled = !bPaused;
            //gameObject.GetComponent<FirstPersonAttack>().enabled = !bPaused;
            
        }
	}
}
