using UnityEngine;
using System.Collections;


public abstract class Item : MonoBehaviour {

	//TODO maybe making a struct for the stats will make it easy for passing?

	protected int weight;
	protected string name;
	protected GUISkin itemImage; //TODO do we need a 2d for inventory & a 3D for world play"?

	//public abstract bool use (); //TODO maybe a void? not sure bout dis yet

	public int getWeight(){
		if (weight <= 0) {
			weight = 1;
		}
		return weight;
	}

	public void setWeight(int newWeight){
		if (newWeight <= 0) {
			weight = 1;
		}
		weight = newWeight;
	}

	public void setName(string newName){
		if(newName.Equals("")){
			name = "No Name";
		}

		name = newName;
	}

	public string getName(){
		if (name.Equals ("")) {
			name = "No Name";
		}

		return name;
	}

	protected void setSkin(GUISkin newSkin){
		if (newSkin == null) {
			//TODO add some default item skin to this thingy
		}

		itemImage = newSkin;
	}

	public GUISkin getSkin(){
		if (itemImage == null) {
			//TODO some default thing here
		}

		return itemImage;
	}


}
