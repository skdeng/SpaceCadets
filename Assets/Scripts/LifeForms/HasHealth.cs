using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour {

	protected float fHP = 56f;

	public void ReceiveDamage( float pAmount )
	{
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
		GetComponentInParent<Animal> ().die();
	}
}
