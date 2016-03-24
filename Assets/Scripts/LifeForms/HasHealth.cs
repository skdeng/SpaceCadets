using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour {

	public float fHP = 100f;

	public void ReceiveDamage( float pAmount )
	{
		fHP -= pAmount;
		if (fHP <= 0) {
			Die ();
		}
	}

	void Die() 
	{
		Destroy(gameObject);
	}
}
