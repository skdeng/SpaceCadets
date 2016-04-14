using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int nHealth;
    public UIManager uiManager;
    private float fLasttime;
	private bool bGameOver = false;
	public GameObject gameover;

	// Use this for initialization
	void Start () {
        fLasttime = Time.time;

		//gameover = GameObject.Find ("GameOverScreen");
		//gameover.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - fLasttime > 5 && !bGameOver) {
            setHealth(nHealth - 1);
            fLasttime = Time.time;
        } 
	}

    public void setHealth(int nHealth) {
		if (nHealth > 0) {
			this.nHealth = nHealth;
			uiManager.notifyHealthChange (nHealth);
		} else {
			this.nHealth = 0;
			uiManager.notifyHealthChange (0);
			uiManager.gameOverActivate ();
			bGameOver = true;
		}
    }

    public void damage(int nDamage) {
		setHealth (nHealth - nDamage);

    }

    public int getHealth() {
        return nHealth;
    }
}
