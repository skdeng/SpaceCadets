﻿using UnityEngine;
using System.Collections;

public class AuctionHouse : MonoBehaviour {

	IEnumerator Start() {
		return GetHello ();
	}
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        return;
	}

	IEnumerator GetHello(){
		string url = "http://0.0.0.0:5000/getUserInfo?username=sodaman";
		WWW www = new WWW(url);
		yield return www;
		Debug.Log (www.text);
	}
}
