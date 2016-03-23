using UnityEngine;
using System.Collections;

public class Detonation : MonoBehaviour {

	public float fLifeSpan = 3.0f;
	public GameObject gFlare;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Called on collision with another rigidbody 
	void OnCollisionEnter(Collision collision){
		Instantiate (gFlare, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	private void Explode(){
		Destroy (gameObject);
	}
		
}
