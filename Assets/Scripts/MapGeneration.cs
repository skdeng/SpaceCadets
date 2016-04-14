using UnityEngine;
using System.Collections;

public class MapGeneration : MonoBehaviour{
	private long frame = 0;
	Color[] pix;
    GameObject player;
	Color grassCol;
	Color enemyCol;
	Color playerCol;
	Color shipCol;
	Color forwardCol;
	Texture2D result;
	void Start () {
        player = GameObject.Find("Player");
		grassCol = new Color( 0f, 200f, 0f, 0.2f);
		enemyCol = new Color( 200f, 0f, 0f, 0.5f);
		playerCol = new Color (0f, 0f, 200f, 0.5f);
		shipCol = new Color (160f, 0f, 160f, 0.5f);
		forwardCol = new Color (255f, 255f, 0f, 0.5f);	
	}
	// Update is called once per frame
	void Update () {
	}
	private GUIStyle currentStyle = null;

	void OnGUI(){

			pix = new Color[200 * 200];
			


            //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            //int playerx =(int)(players[0].transform.position.x);
            //int playerz = (int)(players[0].transform.position.z);
            int playerx = (int)player.transform.position.x;
            int playerz = (int)player.transform.position.z;
			Vector3 rotation = player.transform.forward;
			//Debug.Log (rotation.ToString());
			
			for( int i = 0; i < pix.Length; i++ )
			{
				pix[i] = grassCol; 	
			}

			rotation = Quaternion.Euler (0, -15, 0) * rotation;
			
			for (int i = 0; i<30; i++) {
				drawForward (pix, rotation, forwardCol);
				rotation = Quaternion.Euler (0, 1, 0) * rotation;
			}	

			//Color all the positions of enemy red
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject enemy in enemies) {
				int enemyx = (int)(enemy.transform.position.x);
				int enemyz = (int)(enemy.transform.position.z);
				if(enemyx > playerx - 95 && enemyx < playerx + 95 && enemyz > playerz - 95 && enemyz < playerz + 95)
				{
				enemyx = enemyx - playerx + 100;
				enemyz = enemyz - playerz + 100;
				//Debug.Log (enemyx +", "+enemyz);
				colorShape(pix, enemyx,enemyz, enemyCol,"diamond");
				}
			}
			
			int shipx = 0;
			int shipz = 0;
			if(shipx > playerx - 95 && shipx < playerx + 95 && shipz > playerz - 95 && shipz < playerz + 95)
			{
				shipx = shipx - playerx + 100;
				shipz = shipz - playerz + 100;
				//Debug.Log (enemyx +", "+enemyz);
				colorShape(pix, shipx,shipz, shipCol,"ship");
			}

			
			//create a cross for the main player
			
			colorShape(pix, 100, 100, playerCol,"square");
			//Debug.Log ((100 + (int)(rotation.x * 10)) + ", " + (100 + (int)(rotation.z * 10)));
			
			
			
		 	// apply pix to create a texture
			result = new Texture2D( 200, 200 );
			result.SetPixels( pix );
			result.Apply();
			currentStyle = new GUIStyle (GUI.skin.box);
			currentStyle.normal.background = result;
			
			//create a box from the pix texture
			GUI.Box (new Rect (Screen.width - 200,0,200,200), "", currentStyle );

	
	}
	int translatePosition(double position){
		//converts a map of -500,-500,500,500 to 0,0,200,200
		return (int)((position + 500) / 5);
	}
	void colorShape(Color[] pix, int playerx, int playerz, Color color, string shape){
		if (shape.Equals ("square")) {
			pix [getPixIndex (playerz, playerx)] = color;
			pix [getPixIndex (playerz, playerx) - 1] = color;
			pix [getPixIndex (playerz, playerx) + 1] = color;
			pix [getPixIndex (playerz, playerx) - 200] = color;
			pix [getPixIndex (playerz, playerx) + 200] = color;
			pix [getPixIndex (playerz, playerx) - 200 - 1] = color;
			pix [getPixIndex (playerz, playerx) - 200 + 1] = color;
			pix [getPixIndex (playerz, playerx) + 200 - 1] = color;
			pix [getPixIndex (playerz, playerx) + 200 + 1] = color;
		} else if (shape.Equals ("diamond")) {
			pix [getPixIndex (playerz, playerx)] = color;
			pix [getPixIndex (playerz, playerx) - 1] = color;
			pix [getPixIndex (playerz, playerx) + 1] = color;
			pix [getPixIndex (playerz, playerx) - 200] = color;
			pix [getPixIndex (playerz, playerx) + 200] = color;
		} else if (shape.Equals ("ship")) {
			pix [getPixIndex (playerz, playerx)] = color;
			pix [getPixIndex (playerz, playerx) - 1] = color;
			pix [getPixIndex (playerz, playerx) + 1] = color;
			pix [getPixIndex (playerz, playerx) - 200] = color;
			pix [getPixIndex (playerz, playerx) + 200] = color;
			pix [getPixIndex (playerz, playerx) - 200 - 1] = color;
			pix [getPixIndex (playerz, playerx) - 200 + 1] = color;
			pix [getPixIndex (playerz, playerx) + 200 - 1] = color;
			pix [getPixIndex (playerz, playerx) + 200 + 1] = color;
			pix [getPixIndex (playerz, playerx) - 2] = color;
			pix [getPixIndex (playerz, playerx) + 2] = color;
			pix [getPixIndex (playerz, playerx) - 400] = color;
			pix [getPixIndex (playerz, playerx) + 400] = color;
		} else if(shape.Equals ("dot")){
			pix [getPixIndex (playerz, playerx)] = color;
		}
	}
	int getPixIndex(int zposition, int xposition){
		return zposition * 200 + xposition;
	}

	void drawForward(Color[] pix, Vector3 rotation, Color col){
		colorShape(pix, 100 + (int)(rotation.x*7), 100 + (int)(rotation.z*7), col, "dot");
		colorShape(pix, 100 + (int)(rotation.x*8), 100 + (int)(rotation.z*8), col, "dot");
		colorShape(pix, 100 + (int)(rotation.x*9), 100 + (int)(rotation.z*9), col, "dot");
		colorShape(pix, 100 + (int)(rotation.x*10), 100 + (int)(rotation.z*10), col, "dot");
		colorShape(pix, 100 + (int)(rotation.x*11), 100 + (int)(rotation.z*11), col, "dot");
		colorShape(pix, 100 + (int)(rotation.x*12), 100 + (int)(rotation.z*12), col, "dot");
		colorShape(pix, 100 + (int)(rotation.x*13), 100 + (int)(rotation.z*13), col, "dot");
	}
}
