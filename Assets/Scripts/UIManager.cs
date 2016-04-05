using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private bool bPaused = false;

    public MusicManager musicManager;

    //pause menu options
    private Button resumeButton;
    private Slider musicSlider;
    private Toggle musicToggle;

	// Use this for initialization
	void Start () {
        resumeButton = GameObject.Find("resumeButton").GetComponent<Button>();
        musicSlider = GameObject.Find("musicSlider").GetComponent<Slider>();
        musicToggle = GameObject.Find("musicToggle").GetComponent<Toggle>();

        resumeButton.onClick.AddListener(delegate { togglePause(); });
        musicSlider.onValueChanged.AddListener(delegate { changeVolume(); });
        musicToggle.onValueChanged.AddListener(delegate { toggleMusic(); });
        
	}
	
	// Update is called once per frame
	void Update () {
	  
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

        GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = !bPaused;
        GameObject.Find("Player").GetComponent<FirstPersonShooting>().enabled = !bPaused;
        //gameObject.GetComponent<FirstPersonAttack>().enabled = !bPaused;

        GameObject.Find("PauseCanvas").GetComponentInChildren<Canvas>().enabled = bPaused;
        GameObject.Find("IngameCanvas").GetComponentInChildren<Canvas>().enabled = !bPaused;

        GameObject.Find("Animals").GetComponentInChildren<Horse>().enabled = !bPaused;
        GameObject.Find("Animals").GetComponentInChildren<Spider>().enabled = !bPaused;
    }

    public void changeVolume() {
        musicManager.setVolume(musicSlider.value);
    }

    public void toggleMusic() {
        musicManager.pause(!musicToggle.isOn);
    }
}
