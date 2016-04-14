using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour, Interactable {
	//may not be abstract?... we will see in time
	//protected for private access and inheritance
	public float fMaxHealth = 20f;

	protected growthFunction growth;
	protected Vector3 curScale;

    private Terrain terrain;

	public void Start(){
		HasHealth aHealth = GetComponentInParent<HasHealth> ();

		aHealth.setHealth (fMaxHealth);
		setGrowth (GetComponentInParent<growthFunction> ());

		curScale = transform.localScale;
	}

    public void place() {
        terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        if (terrain != null) {
            Vector3 p = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
            transform.position = new Vector3(p.x, terrain.SampleHeight(p), p.z);
        }
    }

	public void Update(){
        grow();
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
