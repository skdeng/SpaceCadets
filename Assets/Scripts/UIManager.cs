using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private bool bPaused = false;

    public MusicManager musicManager;
    public GameManager gameManager;

    public GameObject player;
    public GameObject crosshair;
    public GameObject minimap;
	public GameObject gameover;
	public GameObject winscreen;
    public Animal horse, spider;

    GameObject pauseGUI;
    GameObject pauseMenu;
    Transform inventoryGUI;
    InstantGuiButton continueButton;

    Slider healthSlider;
    Slider progressSlider;
   
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        crosshair = GameObject.Find("crosshair");
        minimap = GameObject.Find("minimap");

        healthSlider = GameObject.Find("HealthSlider").gameObject.GetComponent<Slider>();
        progressSlider = GameObject.Find("progressSlider").GetComponent<Slider>();

		gameover = GameObject.Find ("GameOverScreen");
		winscreen = GameObject.Find ("Win");
        pauseGUI = GameObject.Find("PauseGUI");
        pauseMenu = GameObject.Find("Pause Menu");
        continueButton = GameObject.Find("Continue").GetComponent<InstantGuiButton>();
        pauseMenu.SetActive(false);
        pauseGUI.SetActive(false);
		gameover.SetActive (false);
		winscreen.SetActive (false);

        horse = GameObject.Find("horses").GetComponentInChildren<Horse>();
        spider = GameObject.Find("spiders").GetComponentInChildren<Spider>();

        inventoryGUI = pauseGUI.transform.FindChild("Inventory");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            togglePause();
        }
    }

	public void gameOverActivate(){
		gameover.SetActive (true);
		minimap.SetActive (false);

	}

	public void winScreenActivate(){
		winscreen.SetActive (true);
		minimap.SetActive (false);

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
        
        crosshair.SetActive(!bPaused);
        minimap.SetActive(!bPaused);
        pauseGUI.SetActive(bPaused);
        pauseMenu.SetActive(bPaused);
        continueButton.pressed = false;
        continueButton.check = false;

        //horse.enabled = !bPaused;
        //spider.enabled = !bPaused;
    }

    public void saveGame() {
        GameObject saveMenu = transform.FindChild("PauseGUI").transform.FindChild("Save Game").gameObject;
        string sUsername = saveMenu.GetComponentInChildren<InstantGuiInputText>().text;
        gameManager.setUsername(sUsername);
        gameManager.save();
        saveMenu.SetActive(false);
    }

    public void removeItem(int slotid) {
        inventoryGUI.FindChild(slotid.ToString()).FindChild("content").GetComponent<InstantGuiElement>().mainGuiTexture = null;
    }

    public void notifyHealthChange(int nHealth) {
        healthSlider.value = nHealth;
    }

    public void notifyProgressChange(int nProgress) {
        progressSlider.value = nProgress;
    }
}
