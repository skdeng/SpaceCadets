using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    TerrainGeneration terrainScript;
    Terrain terrain;
    int nTerrainSeed;
    int nLifeFormAbundance;

	// Use this for initialization
	void Start () {
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
        
        //int nAnimalCount = nLifeFormAbundance * 20;
        //GameObject horsePrefab = Resources.Load<GameObject>("horse");
        //GameObject spiderPrefab = Resources.Load<GameObject>("spider");
        //for (int i = 0; i < nAnimalCount; i++) {
        //    float nX = Random.Range(-450, 450);
        //    float nZ = Random.Range(-450, 450);
        //    Instantiate(horsePrefab, new Vector3(nX, 0, nZ), Quaternion.identity);

        //    nX = Random.Range(-450, 450);
        //    nZ = Random.Range(-450, 450);
        //    Instantiate(spiderPrefab, new Vector3(nX, 0, nZ), Quaternion.identity);
        //}
    }

    public void startNewGame() {
        nLifeFormAbundance = Random.Range(2, 5);
        nTerrainSeed = 1000000 + Random.Range(100, 100000);
    }

    public void save() {

    }

    public bool load(string sUsername, string sPassword) {

        return true;
    }
}
