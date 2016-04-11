using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour {

	protected float fHP = 100f;
	protected float fRandFactor = 50f;

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
		GameObject aPickup;

		aPickup = GetComponentInParent<Animal> ().dropItem ();

		if (aPickup != null && Random.Range(0,100) > fRandFactor) {
			Instantiate (aPickup, transform.position, Quaternion.identity);
		}

		GetComponentInParent<Animal> ().die();
	
	}
}