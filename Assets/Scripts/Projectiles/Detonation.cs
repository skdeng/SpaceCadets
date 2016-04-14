using UnityEngine;
using System.Collections;

public class Detonation : MonoBehaviour {

	public float fLifeSpan;
	public GameObject gFlare;
	         
	FightBehaviour fb;



	// Use this for initialization
	void Start () {
		fb = GameObject.FindGameObjectWithTag ("Player").GetComponent<FightBehaviour> ();

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

		HasHealth aHealth ;
		Interactable aInteractable;
		GameObject target = collision.gameObject;


		Instantiate (gFlare, transform.position, Quaternion.identity);
		Destroy (gameObject);
		if (target.tag == "Interactable" || target.tag == "Enemy") 
		{
			aInteractable = target.GetComponent<Interactable> ();
			aInteractable.hit (fb.getWeapon().damage);

            //Destroy(target);
		}	
	}
		
		
}
