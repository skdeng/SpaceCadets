using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int nHealth;
    public UIManager uiManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setHealth(int nHealth) {
        this.nHealth = nHealth;
        uiManager.notifyHealthChange(nHealth);
    }

    public int getHealth() {
        return nHealth;
    }
}
