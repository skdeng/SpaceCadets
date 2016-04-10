using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour {

	protected float fHP = 100f;
	public GameObject aPickup;
	public void ReceiveDamage( float pAmount ){
		fHP -= pAmount;
		if (fHP <= 0) {
			Die ();
		}
	}
		
	public void BuffHealth (float pAmount)
	{
		fHP += pAmount;
	}

	public float GetHealth ()
	{
		return fHP;
	}

	void Die() 
	{
		if (aPickup != null) {
			if (Random.Range (1, 11)<= 2) {
				Instantiate(aPickup, transform.position, Quaternion.identity); 
			}
		GetComponentInParent<Animal> ().die();
	}
	}
}