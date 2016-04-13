using UnityEngine;
using System.Collections;

//Randomly generate a terrain using the diamon square technique
public class TerrainGeneration : MonoBehaviour {

	//seed for the random number generator
	public int Seed = 10000101;
	//width of the heightmap
	private int Width;
	//length of the heightmap
	private int Height;

	//height map as an array of float, we could also use a 2d array
	private float[] heightMap = null;

	//terrain object to reference the terrain in use
	Terrain terrain;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	//apply the heightmap to the active terrain
	public void applyHeightMap() {
		//construct a height array 
		float[,] heights = terrain.terrainData.GetHeights (0, 0, Width, Height);
		for (int y = 0; y < Height; y++) {
			for (int x = 0; x < Width; x++) {
					heights [y,x] = heightMap [x + y * Width];
			}
		}
		//save the height map to the terrain
		terrain.terrainData.SetHeights (0, 0, heights);
	}

	//generate a new heightmap using diamond square alg.
	public void generate() {
        Random.seed = Seed;
        terrain = GetComponent<Terrain>();
        Width = terrain.terrainData.heightmapWidth;
        Height = terrain.terrainData.heightmapHeight;

        if (heightMap == null)
            heightMap = new float[Width * Height];

		//randomize the size of the largest feature
        //int nFeatureSize = (int) Mathf.Pow(2.0f, (float) Random.Range (7, 9));
        int nFeatureSize = 256;
		for (int y = 0; y < Height; y += nFeatureSize) {
			for (int x = 0; x < Width; x += nFeatureSize) {
				float dRandomNumber = (UnityEngine.Random.value * 2) - 1;
				setSample (x, y, dRandomNumber);
			}
		}

		int nSampleSize = nFeatureSize;
		float dScale = 0.5f;

		//diamond square
		while (nSampleSize > 1) {
			diamondSquare (nSampleSize, dScale);
			nSampleSize /= 2;
			dScale /= 2.0f;
		}
			
		//adjust and renormalize the final height to [0,1]
        float adjust = 0.3f;
		for (int y = 0; y < Height; y++) {
			for (int x = 0; x < Width; x++) {
				heightMap [x + y * Width] = adjust * (heightMap [x + y * Width] + 1) / 2;
			}
		}

		print (nFeatureSize + " " + adjust);
	}

	//apply diamond square algorithm once
    //param: nStep  - size of square or diamond
    //       dScale - magnitude of the height change
	private void diamondSquare(int nStep, float dScale) {
		int nHalfStep = nStep / 2;

		for (int y = nHalfStep; y < Height + nHalfStep; y += nStep)
		{
			for (int x = nHalfStep; x < Width + nHalfStep; x += nStep)
			{
				sampleSquare(x, y, nStep, randN() * dScale);
			}
		}

		for (int y = 0; y < Height; y += nStep)
		{
			for (int x = 0; x < Width; x += nStep)
			{
				sampleDiamond(x + nHalfStep, y, nStep, randN() * dScale);
				sampleDiamond(x, y + nHalfStep, nStep, randN() * dScale);
			}
		}
	}

	//Apply square step once
    //param: nX     - x position
    //       nY     - y position
    //       nSize  - size of the square
    //       dVal   - value of the height change
	private void sampleSquare(int nX, int nY, int nSize, float dVal) {
		int nHalfSize = nSize / 2;

		float dA = sample(nX - nHalfSize, nY - nHalfSize);
		float dB = sample(nX + nHalfSize, nY - nHalfSize);
		float dC = sample(nX - nHalfSize, nY + nHalfSize);
		float dD = sample(nX + nHalfSize, nY + nHalfSize);
		setSample(nX, nY, (dA + dB + dC + dD) / 4.0f + dVal);
	}

    //Apply diamond step once
    //param: nX     - x position
    //       nY     - y position
    //       nSize  - size of the diamond
    //       dVal   - value of the height change
    private void sampleDiamond(int nX, int nY, int nSize, float dVal) {
		int nHalfSize = nSize / 2;

		float dA = sample(nX - nHalfSize, nY);
		float dB = sample(nX + nHalfSize, nY);
		float dC = sample(nX, nY - nHalfSize);
		float dD = sample(nX, nY + nHalfSize);
		setSample(nX, nY, (dA + dB + dC + dD) / 4.0f + dVal);
	}

	//Get the height at a given point
    //param: nX - x position
    //       nY - y position
    //return: value of the height
	public float sample(int nX, int nY) {
		if (nX >= Width) nX = Width - 1;
		if (nX < 0) nX = 0;
		if (nY >= Height) nY = Height - 1;
		if (nY < 0) nY = 0;

		return heightMap[nX + nY * Width];
	}

	//Set the height at a given point
    //param: nX     - x position
    //       nY     - y position
    //       dVal   - value of the height
	private void setSample(int nX, int nY, float dVal)	{
		if (nX >= Width) nX = Width - 1;
		if (nX < 0) nX = 0;
		if (nY >= Height) nY = Height - 1;
		if (nY < 0) nY = 0;
		heightMap[nX + nY * Width] = dVal;
	}

	//Returns a random number between -1 and 1 using unity's random engine
	private float randN() {
		return (UnityEngine.Random.value * 2) - 1;
	}
}
