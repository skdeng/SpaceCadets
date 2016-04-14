using UnityEngine;
using System.Collections;


public abstract class Item : MonoBehaviour {

	//TODO maybe making a struct for the stats will make it easy for passing?
	protected int weight;
	protected string name;
	protected string image; //TODO do we need a 2d for inventory & a 3D for world play"?
	public GameObject aPrefab;
	protected int randRange = 11;
	public abstract void consume();

	//public abstract bool use (); //TODO maybe a void? not sure bout dis yet
	public GameObject dropPrefab(){
		if (aPrefab != null) {
			if (Random.Range (1, randRange)<= 2) {
				return aPrefab;
			}
		}

		return aPrefab;
	}

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

	public void setImage(string path){
		image = path;
	}

	public string getImage(){
		return image;
	}

    public abstract int getID();
}
