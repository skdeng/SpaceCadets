using UnityEngine;
using System.Collections;

public class AuctionHouse : MonoBehaviour {

	public InstantGuiInputText input;
	public InstantGuiTextArea textArea;

	IEnumerator Start() {
		textArea.text = "Connecting to computer...\n...\nSuccessfully connected to 361AuctionHouse\n...\n";
		textArea.text = textArea.text + "Press 'b' to view all current items for auction\nPress 'n' to add an item for auction\nPress 'm' to accept a bid for a current item up for auction\n";
		return GetHello ();

	}
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			Debug.Log ("B");
			GetAllAuction();
		}
	}

	IEnumerator GetHello(){
		string url = "http://0.0.0.0:5000/getUserInfo?username=sodaman";
		WWW www = new WWW(url);
		yield return www;
		Debug.Log (www.text);
	}

	IEnumerator GetAllAuction(){
		string url = "http://0.0.0.0:5000/getAllAuctions";
		WWW www = new WWW(url);
		yield return www;
		textArea.text = textArea.text + (www.text)+"\n";
		textArea.text = textArea.text + "done\n";
	} 

}
