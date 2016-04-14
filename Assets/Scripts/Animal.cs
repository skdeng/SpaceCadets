using UnityEngine;
using System.Collections;

//abstract because there is nothing it can really concretely do, and the functions can't be abstract unless the class is
//lifeform is also abstract see: Lifeform
//
public abstract class Animal : MonoBehaviour, Interactable {
	//public so that it is easily manipulatible with Unity
	public string behaviour;
	public float speed = 0.1f;
	public float strength;
	public float fMaxHealth = 100f;

	protected Animator anim;
	protected Item animalItem;
	//protected GameObject aPickup; //prefab item that it drops

    protected float fIdletime = 3;
    protected float fWalkingTime = 2;

    protected float fLasttime = 0;
    protected bool bStartMoving = false;
    protected bool bMoving = false;
    protected Vector3 moveVector;


	public abstract void move ();
	//public abstract void hit(/*Player here*/);
	//public abstract void die ();


	public GameObject dropItem (){
		if (animalItem != null){
			return animalItem.dropPrefab ();
		}

		return null;
	}

    protected Terrain terrain;

    protected Animal() {
        System.Random r = new System.Random();
        fIdletime = ((float)r.NextDouble() + 1) * 3;
        fWalkingTime = ((float)r.NextDouble() + 1) * 3;
    }

    //returns a random move vector
    //return: a random unit vector on the x-z plane
    protected Vector3 randomMove() {
        float fX = Random.Range(-10, 10);
        float fZ = Random.Range(-10, 10);
        Vector3 v = new Vector3(fX, 0, fZ);
        v.Normalize();
        return v;
    }

    //move the animal forward according to its speed
    //adjust the animal's y-position according the height of the terrain
    protected void goForward() {
        Vector3 pos = transform.position;
        transform.Translate(new Vector3(0, 0, speed * Time.timeScale));

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -450, 450), terrain.SampleHeight(transform.position), Mathf.Clamp(transform.position.z, -450, 450));
        
        //Vector3 pos2 = transform.position;
        //float deltaheight = terrain.SampleHeight(pos2) - terrain.SampleHeight(pos);
        //transform.Translate(new Vector3(0, deltaheight, 0));
    }

    //prepare the animal to start walking animation
    //param: anim   - animator of the animal
    protected void startWalking(Animator anim) {
        if (anim.IsInTransition(0) && bStartMoving) {
            bMoving = true;
            bStartMoving = false;
            transform.rotation = Quaternion.LookRotation(moveVector) * transform.rotation;
        }
    }

	public Animator getAnim(){
		return anim;
	}
    

	//prepare the animal for idle animation
    //param: anim   - animator of the animal
    protected void stopWalking(Animator anim) {
        if (anim.IsInTransition(0)) {
            bMoving = false;
            fLasttime = Time.time;
        }
    }

	protected void updateMethod(){

	}

	//essentially a super start method to be called in the child

	public abstract void die ();
	public abstract void hit(float damage);


}
