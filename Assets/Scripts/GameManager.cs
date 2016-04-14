using UnityEngine;
using System.Collections;
using SimpleJson;

public class GameManager : MonoBehaviour {

    TerrainGeneration terrainScript;
    Terrain terrain;
    int nTerrainSeed;
    GameObject animals;
    GameObject plants;
    public GameObject player;
    string sUsername;
    Vector3 shipPosition;

	// Use this for initialization
	void Start () {
        animals = GameObject.Find("Animals");
        plants = GameObject.Find("Plants");
        startNewGame();
        setupGame();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void setupGame() {
        //generate random terrain
        terrainScript = GameObject.Find("Terrain").GetComponent<TerrainGeneration>();
        terrainScript.Seed = nTerrainSeed;
        terrainScript.generate();
        terrainScript.applyHeightMap();

        terrain = Terrain.activeTerrain;
        shipPosition = GameObject.Find("ship").transform.position;
        GameObject.Find("ship").transform.position = new Vector3(shipPosition.x, terrain.SampleHeight(shipPosition) + 10, shipPosition.z);

        //activate the animals
        //animals.transform.FindChild("horses").gameObject.SetActive(true);
        //animals.transform.FindChild("spiders").gameObject.SetActive(true);

        //place the player
        player.transform.position = new Vector3(shipPosition.x+20, shipPosition.y, shipPosition.z+20);

        foreach (Transform tree in plants.transform) {
            tree.GetComponent<Plant>().place();
        }
    }

    public void startNewGame() {
        nTerrainSeed = 1000000 + Random.Range(100, 100000);
        player.GetComponent<Player>().setHealth(100);
    }

    public void save() {
        string url = "http://0.0.0.0:5000/getUserInfo?";
        if (sUsername == null) {
            print("Invalid username");
        }
        url += "username=" + sUsername;
        url += "&positionx=" + player.transform.position.x;
        url += "&positiony=" + player.transform.position.y;
        url += "&positionz=" + player.transform.position.z;
        url += "&health=" + player.GetComponent<Player>().getHealth();
    }

    public bool load(string sUsername) {
        //string url = "http://0.0.0.0:5000/getUserInfo?username=sodaman";
        //WWW request = new WWW(request);
        
        return true;
    }

    public void setUsername(string s) {
        sUsername = s;
    }
}
