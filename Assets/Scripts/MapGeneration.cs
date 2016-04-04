using UnityEngine;
using System.Collections;

public class MapGeneration : MonoBehaviour{
	private long frame = 0;
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
	private GUIStyle currentStyle = null;

	void OnGUI(){
			Color[] pix = new Color[200 * 200];
			//Color all pixels green	
			for( int i = 0; i < pix.Length; i++ )
			{
				pix[i] = new Color( 0f, 200f, 0f, 0.5f);	
			}

			//Color all the positions of enemy red
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject enemy in enemies) {
				int enemyx = (int)(enemy.transform.position.x+500)/5;
				int enemyz = (int)(enemy.transform.position.z+500)/5;
			//	Debug.Log ("x: "+enemyx+"  z: "+enemyz);
				pix[enemyz*200 + enemyx -200] = new Color( 200f, 0f, 0f, 0.5f);
			}

			//create a cross for the main player
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
			int playerx = (int)(players[0].transform.position.x + 500) / 5;
			int playerz = (int)(players[0].transform.position.z + 500) / 5;
			
			colorPlayer(pix, playerx, playerz);
			
		 	// apply pix to create a texture
			Texture2D result = new Texture2D( 200, 200 );
			result.SetPixels( pix );
			result.Apply();
			currentStyle = new GUIStyle (GUI.skin.box);
			currentStyle.normal.background = result;
			
			//create a box from the pix texture
			GUI.Box (new Rect (Screen.width - 200,0,200,200), "Map", currentStyle );

	
	}

	void colorPlayer(Color[] pix, int playerx, int playerz){
		//middle square
		pix [playerz * 200 + playerx - 200] = new Color (0f, 0f, 200f, 0.5f);

		pix [playerz * 200 + playerx - 200-1] = new Color (0f, 0f, 200f, 0.5f);
		pix [playerz * 200 + playerx - 200+1] = new Color (0f, 0f, 200f, 0.5f);

		pix [playerz * 200 + playerx - 200-200] = new Color (0f, 0f, 200f, 0.5f);
		pix [playerz * 200 + playerx - 200+200] = new Color (0f, 0f, 200f, 0.5f);

	}
}
