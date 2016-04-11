using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private bool bPaused = false;

    public MusicManager musicManager;

    public GameObject player;
    public Canvas ingameCanvas;
    public Animal horse, spider;

    GameObject pauseGUI;
    GameObject pauseMenu;
    InstantGuiButton continueButton;
   
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        ingameCanvas = GameObject.Find("IngameCanvas").GetComponentInChildren<Canvas>();
        horse = GameObject.Find("Animals").GetComponentInChildren<Horse>();
        spider = GameObject.Find("Animals").GetComponentInChildren<Spider>();

        pauseGUI = GameObject.Find("PauseGUI");
        pauseMenu = GameObject.Find("Pause Menu");
        continueButton = GameObject.Find("Continue").GetComponent<InstantGuiButton>();
        pauseMenu.SetActive(false);
        pauseGUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            togglePause();
        }
    }

    public void togglePause() {
        if (Cursor.lockState == CursorLockMode.Locked) {
            Cursor.lockState = CursorLockMode.None;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
        }

        bPaused = !bPaused;

        Time.timeScale = 1 - Time.timeScale;
        Cursor.visible = bPaused;

        musicManager.pause(bPaused);

        player.GetComponent<FirstPersonController>().enabled = !bPaused;
        player.GetComponent<FirstPersonShooting>().enabled = !bPaused;
        //player.GetComponent<FirstPersonAttack>().enabled = !bPaused;
        
        ingameCanvas.enabled = !bPaused;
        pauseGUI.SetActive(bPaused);
        pauseMenu.SetActive(bPaused);
        continueButton.pressed = false;
        continueButton.check = false;

        horse.enabled = !bPaused;
        spider.enabled = !bPaused;
    }
}
