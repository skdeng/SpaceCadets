using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private bool bPaused = false;

    public MusicManager musicManager;

    public GameObject player;
    public GameObject crosshair;
    public GameObject minimap;
    public Animal horse, spider;

    GameObject pauseGUI;
    GameObject pauseMenu;
    Transform inventoryGUI;
    InstantGuiButton continueButton;

    Slider healthSlider;
   
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        crosshair = GameObject.Find("crosshair");
        minimap = GameObject.Find("minimap");

        healthSlider = GetComponentInChildren<Slider>();

        pauseGUI = GameObject.Find("PauseGUI");
        pauseMenu = GameObject.Find("Pause Menu");
        continueButton = GameObject.Find("Continue").GetComponent<InstantGuiButton>();
        pauseMenu.SetActive(false);
        pauseGUI.SetActive(false);

        inventoryGUI = pauseGUI.transform.FindChild("Inventory");
    }

    public void delayedInit() {
        horse = GameObject.Find("horses").GetComponentInChildren<Horse>();
        spider = GameObject.Find("spiders").GetComponentInChildren<Spider>();
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
        
        crosshair.SetActive(!bPaused);
        minimap.SetActive(!bPaused);
        pauseGUI.SetActive(bPaused);
        pauseMenu.SetActive(bPaused);
        continueButton.pressed = false;
        continueButton.check = false;

        //horse.enabled = !bPaused;
        //spider.enabled = !bPaused;
    }

    //public void addItem(int slotid, int itemid) {
    //    inventoryGUI.FindChild(slotid.ToString()).FindChild("content").GetComponent<InstantGuiElement>().mainGuiTexture.texture = null;
    //    inventoryGUI.FindChild(slotid.ToString()).FindChild("content").GetComponent<InstantGuiElement>().mainGuiTexture.texture = Resources.Load("items/item" + itemid) as Texture2D;
    //}

    public void removeItem(int slotid) {
        inventoryGUI.FindChild(slotid.ToString()).FindChild("content").GetComponent<InstantGuiElement>().mainGuiTexture = null;
    }

    public void notifyHealthChange(int nHealth) {
        healthSlider.value = nHealth;
    }
}
