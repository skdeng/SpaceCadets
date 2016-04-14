using UnityEngine;
using System.Collections;
using SimpleJson;

public class GameManager : MonoBehaviour {

    TerrainGeneration terrainScript;
    Terrain terrain;
    int nTerrainSeed;
    GameObject animals;
    GameObject plants;
    GameObject ship;
    public GameObject player;
    string sUsername;
    Vector3 shipPosition;
    SpaceShip shipScript;

    string serverURL;

	// Use this for initialization
	void Start () {
        animals = GameObject.Find("Animals");
        plants = GameObject.Find("Plants");
        shipScript = GameObject.Find("ship").GetComponent<SpaceShip>();
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

        ship = GameObject.Find("ship");
        terrain = Terrain.activeTerrain;
        shipPosition = ship.transform.position;
        ship.transform.position = new Vector3(shipPosition.x, terrain.SampleHeight(shipPosition) + 10, shipPosition.z);

        //activate the animals
        foreach (Transform horse in animals.transform.FindChild("horses").transform) {
            horse.GetComponent<Horse>().place();
        }
        foreach (Transform spider in animals.transform.FindChild("spiders").transform) {
            spider.GetComponent<Spider>().place();
        }

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
        string url = "http://0.0.0.0:5000/updatePlayer?";
        if (sUsername == null) {
            print("Invalid username");
        }
        url += "username=" + sUsername;
        url += "&positionx=" + player.transform.position.x;
        url += "&positiony=" + player.transform.position.y;
        url += "&positionz=" + player.transform.position.z;
        url += "&health=" + player.GetComponent<Player>().getHealth();

        InventoryController inventory = GameObject.Find("IngameCanvas").transform.FindChild("Inventory").GetComponent<InventoryController>();
        string sInventory = "";
        for (int i = 0; i < 9; i++) {
            sInventory += inventory.getItem(i) + ",";
        }
        url += "&inventory=" + sInventory;
        url += "&progress=" + ship.GetComponent<SpaceShip>().getProgress();

    }

    public bool load(string sUsername) {
        string url = "http://0.0.0.0:5000/getUserInfo?username="+sUsername;
        WWW request = new WWW(url);
        print(request.ToString());
        return true;
    }

    public void setUsername(string s) {
        sUsername = s;
    }

    public void applyPart() {
        if ((player.transform.position - shipPosition).magnitude < 50) {
            shipScript.applyPart();
            if (shipScript.getProgress() >= 100) {
                win();
            }
        }
    }

    private void win() {
        GameObject.Find("UIManager").GetComponent<UIManager>().winScreenActivate();
    }
}
