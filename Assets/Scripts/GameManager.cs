using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    TerrainGeneration terrainScript;
    int nTerrainSeed;

	// Use this for initialization
	void Start () {
        Random.seed = (int) Time.time;
        //generate random terrain
        terrainScript = GameObject.Find("Terrain").GetComponent<TerrainGeneration>();
        terrainScript.Seed = nTerrainSeed = 10000000 + Random.Range(100, 1000000);
        terrainScript.generate();
        terrainScript.applyHeightMap();

        //GameObject.Find("ship").transform.position = terrainScript.sample()

        //spawn random animals
        //int nAbundance = 1;
        //int nAnimalCount = nAbundance * 50;
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void startNew() {
        //int nAbdun
    }

    public void save() {

    }

    public bool load(string sUsername, string sPassword) {

        return true;
    }
}
