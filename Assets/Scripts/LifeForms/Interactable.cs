using UnityEngine;
using System.Collections;

public interface Interactable {
	//method common to the strategies
	void hit(float damage);
	void die();
	GameObject dropItem();

}