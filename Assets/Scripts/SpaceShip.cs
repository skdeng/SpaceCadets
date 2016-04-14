using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

    private int nProgress;
    private UIManager uiManager;

    SpaceShip() {
        nProgress = 0;
    }

	// Use this for initialization
	void Start () {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void applyPart() {
        nProgress += 5;
        uiManager.notifyProgressChange(nProgress);
    }

    public int getProgress() {
        return nProgress;
    }
}
