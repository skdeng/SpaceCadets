using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public sealed class Inventory : MonoBehaviour {
	public List<Item> inventory;

	private int nMaxSpace;
	private int nCount;

	private static Inventory instance = null;
	private static readonly object padlock = new object();

	private const int MAXSPACE = 10;

	private Inventory()
	{
		nMaxSpace = 	MAXSPACE;
		nCount = 0;
		inventory = new List<Item>();
	} 

	/* private Inventory(int space)
    {
    	nMaxSpace = space;
    	nCount = 0;
    	List<Item> = new List<Item>();
    }
    */

	public static Inventory Instance{
		get
		{
			lock (padlock)
			{
				if (instance == null)
				{
					instance = new Inventory();
				}
				return instance;
			}
		}
	}

	public bool add(Item anItem){
		if (!(nMaxSpace >= nCount)) {
			inventory.Add (anItem);
			return true;
		}
		return false;
	}

	public bool remove(Item anItem) {
		if(!inventory.Remove(anItem)){
			/*if(!inventory.Exists(new Predicate<Item>(anItem))){
				throw new ArgumentException("Hey bud, that Item is not in the inventory at this time. Some shit must've gone wrong");
			}*/
			return false;
		}

		return true;
	}


}

