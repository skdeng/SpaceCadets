using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int nHealth;
    public UIManager uiManager;
    private float fLasttime;

	// Use this for initialization
	void Start () {
        fLasttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - fLasttime > 10) {
            setHealth(nHealth - 1);
            fLasttime = Time.time;
        } 
	}

    public void setHealth(int nHealth) {
        this.nHealth = nHealth;
        uiManager.notifyHealthChange(nHealth);
    }

    public int getHealth() {
        return nHealth;
    }
}
