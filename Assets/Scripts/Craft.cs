using UnityEngine;
using System.Collections;

public class Craft : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int craft(int[] items) {
        int[] sortedItems = simpleSort(items);

        

        return 0;
    }

    public int[] simpleSort(int[] items) {
        int[] sorted = new int[items.Length];
        for (int i = 0; i < items.Length; i++) {
            int nMin = 100;
            for (int k = i; k < items.Length; k++) {
                if (items[k] < nMin) {
                    nMin = items[k];
                }
            }
            sorted[i] = nMin;
        }
        return sorted;
    }

    private bool matchRecipe(int[] items, string recipe) {
        bool eq = true;

        //for (int i = 0; i < recipeInt.Length; i++ ) {
        //    recipeInt[i] = (int)(recipe[i]);
        //}

        return eq;
    }
}
