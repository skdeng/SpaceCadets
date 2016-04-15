using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

	public string levelToLoad;
	public Button loadGame;
	public Button newGame;
	public Button quitGame;
	public InputField username;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (loadGame.onClick() ) {
//			Application.LoadLevel(levelToLoad);
//		}
	}
	void Awake(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
		loadGame.onClick.AddListener(loadPreviousGame);
		newGame.onClick.AddListener(createNewGame);
		quitGame.onClick.AddListener(exitGame);
	}

	void loadPreviousGame(){
		GameManager.sUsername = username.text;
		GameManager.startNew = false;
		Application.LoadLevel(levelToLoad);
	}
	void createNewGame(){
		GameManager.sUsername = username.text;
		GameManager.startNew = true;
		Application.LoadLevel(levelToLoad);
	}

	void exitGame(){
		Application.Quit ();
	}
}
