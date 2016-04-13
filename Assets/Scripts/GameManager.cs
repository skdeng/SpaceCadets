using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    TerrainGeneration terrainScript;
    Terrain terrain;
    int nTerrainSeed;
    int nLifeFormAbundance;
    GameObject animals;
    GameObject player;

	// Use this for initialization
	void Start () {
        animals = GameObject.Find("Animals");
        player = GameObject.Find("Player");
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
        Vector3 shipPosition = GameObject.Find("ship").transform.position;
        GameObject.Find("ship").transform.position = new Vector3(shipPosition.x, terrain.SampleHeight(shipPosition) + 10, shipPosition.z);

        //activate the animals
        animals.transform.FindChild("horses").gameObject.SetActive(true);

        //place the player
        player.transform.position = new Vector3(shipPosition.x + 10, shipPosition.y, shipPosition.z);
    }

    public void startNewGame() {
        nLifeFormAbundance = Random.Range(2, 5);
        nTerrainSeed = 1000000 + Random.Range(100, 100000);
    }

    public void save() {
        Inventory inventory = player.GetComponent<Inventory>();
        
    }

    public bool load(string sUsername, string sPassword) {

        return true;
    }
}
