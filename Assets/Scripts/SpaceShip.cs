using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

    private int nProgress;

    SpaceShip() {
        nProgress = 0;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void applyPart() {
        nProgress++;
    }

    public int getProgress() {
        return nProgress;
    }
}
