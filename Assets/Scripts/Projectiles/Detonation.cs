using UnityEngine;
using System.Collections;

public class Detonation : MonoBehaviour {

	public float fLifeSpan = 3.0f;
	public GameObject gFlare;

	private float fDamage = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		fLifeSpan -= Time.deltaTime;

		if (fLifeSpan <= 0) {
			Destroy (gameObject);
		}
	
	}

	//Called on collision with another rigidbody 
	void OnCollisionEnter(Collision collision){
		
		GameObject target = collision.gameObject;
		Instantiate (gFlare, transform.position, Quaternion.identity);
		Destroy (gameObject);
		if (target.tag == "Enemy" || 1 == 1) 
		{
			HasHealth aHealth = target.GetComponent<HasHealth>();
			aHealth.ReceiveDamage (fDamage);

		}	
	}
		
		
}
