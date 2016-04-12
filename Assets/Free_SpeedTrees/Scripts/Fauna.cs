using UnityEngine;
using System.Collections;

public class Fauna : MonoBehaviour, Interactable {
	//may not be abstract?... we will see in time
	//protected for private access and inheritance
	public float fMaxHealth = 20f;

	protected growthFunction growth;
	protected Vector3 curScale;

	public void Start(){
		HasHealth aHealth = GetComponentInParent<HasHealth> ();

		aHealth.setHealth (fMaxHealth);
		setGrowth (GetComponentInParent<growthFunction> ());

		curScale = transform.localScale;

	}

	public void Update(){
		grow ();
	}

	//called by something executing the strategy
	public void grow(){
		curScale = growth.getGrowth(curScale);
		transform.localScale = curScale;
	}

	//to change the growth strategy
	public void setGrowth(growthFunction newGrowth){
		growth = newGrowth;
	}

	public void hit(float damage){
		HasHealth aHealth = GetComponentInParent<HasHealth> ();

		aHealth.ReceiveDamage (damage);
	}

	public void die(){
		Destroy (gameObject);
	}

	public GameObject dropItem(){
		return null;
	}
	//TODO when we have merged the sections
	//Item collect(){
	// return itemYielded;
	//}

}
