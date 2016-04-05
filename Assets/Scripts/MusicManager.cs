using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setVolume(float val) {
        GetComponent<AudioSource>().volume = val;
    }

    public void pause(bool p) {
        if (p)
            GetComponent<AudioSource>().Pause();
        else
            GetComponent<AudioSource>().UnPause();
    }
}
