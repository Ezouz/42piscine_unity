using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//using UnityEngine.CoreModule;

public class tilemapConverter : MonoBehaviour {

	public bool[,]		tilesmap = new bool[9,7];
	bool		tmp;
	

	// Use this for initialization
	void Start () {
		Tilemap tilemap = GetComponent<Tilemap>();
		BoundsInt bounds = tilemap.cellBounds;
		//Debug.Log(bounds);
		TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
		//int count = 0;

		for (int j = 0; j < 9; j++){
			for (int k = 0; k < 7; k++){
				tilesmap[j, k] = (allTiles[k * 9 + j] == null);
				//Debug.Log(allTiles[j * 9 + k]);
				//count++;
				//Debug.Log(count);
			}
		}
		
		for (int i = 0; i < 7; i++){
			for (int j = 0; j < 9; j++){
				Debug.Log(tilesmap[j,i] + " ");
			}
			Debug.Log("\n");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
