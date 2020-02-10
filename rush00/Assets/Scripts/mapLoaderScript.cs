using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class mapLoaderScript : MonoBehaviour {

	//public Tilemap			obstacles;
	//bool[,]		tilesmap = new bool[9,7];

	public GameObject		enemy_prefab;
	public GameObject		target;
	public GameObject[]		enemies_tab;
	public List<GameObject>	enemies_list;	
	public int				enemy_count;

	//public PathFind.Grid	grid; 
	

	// Use this for initialization
	void Start () {
		//tilesmap = obstacles.transform.GetComponent<tilemapConverter>().tilesmap;
		//grid = new PathFind.Grid(9, 7, tilesmap);
		enemy_count = 0;
		//enemies_tab[enemy_count] = Instantiate(enemy_prefab, new Vector3(0f, 2.5f, 0f), Quaternion.identity, this.transform);
		//enemies_list.Add(Instantiate(enemy_prefab, new Vector3(-3.5f, -1.5f, 0f), Quaternion.identity, this.transform));
		enemy_count++;
		//enemies_tab[enemy_count].GetComponent<enemyScript>().grid = grid;
		//target = GameObject.FindWithTag("Player");
		
		//_from = new PathFind.Point(1, 1);
		//_to = new PathFind.Point(10, 10);
		///path = PathFind.Pathfinding.FindPath(grid, _from, _to);
	}
	
	// Update is called once per frame
	void Update () {
		//_from = new PathFind.Point(1, 1);
		//_to = new PathFind.Point(10, 10);
		//path = PathFind.Pathfinding.FindPath(grid, _from, _to);
		
	}
}
