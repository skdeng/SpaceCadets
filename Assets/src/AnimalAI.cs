using UnityEngine;
using System.Collections;

//Animal control
public class AnimalAI : MonoBehaviour{

	public enum BEHAVIOUR {
		AGRESSOVE,
		PASSIVE
	}

	public BEHAVIOUR behaviour;
	public float speed;
	public float damage;

	//TODO add reference to player and spawner and other shits

	// Use this for initialization
	void Start () {
		//link other objs this class depends on
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
