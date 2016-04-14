using UnityEngine;
using System.Collections;

public class Ore : MonoBehaviour, Interactable {

	private Terrain terrain;
	private Item rockItem;
	// Use this for initialization
	void Start () {
		rockItem = GetComponentInParent<MineralItem>();

		terrain = GameObject.Find ("Terrain").GetComponent<Terrain>();
		if (terrain != null) {	
			Vector3 p = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
			transform.position = new Vector3(p.x, terrain.SampleHeight(p), p.z);
		}

		float aScale = Random.Range (0.2f, 0.8f);
		transform.localScale += new Vector3(aScale, aScale, aScale);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject dropItem (){
		if (rockItem != null){
			return rockItem.dropPrefab ();
		}

		return null;
	}

	public void die(){
		Destroy(gameObject);
	}

	public void hit(float damage){
		
		HasHealth aHealth = GetComponentInParent<HasHealth> ();
		aHealth.ReceiveDamage (damage);

	}
}
