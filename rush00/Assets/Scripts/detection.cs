using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour {

	// public Transform		prefab;
	// public enemyScript		parentScript;
	// public Vector2			vec2_1, vec2_2;
	// // Use this for initialization
	// void Start () {
	// 	prefab = transform.parent;
	// 	parentScript = prefab.GetComponent<enemyScript>();
	// }

	// public void checkPlayerSight(){
	// 	//Debug.Log("Checking sight");
	// 	vec2_1 = prefab.position;
	// 	vec2_2 = parentScript.target;
	// 	RaycastHit2D hit = Physics2D.Raycast(vec2_1, vec2_2 - vec2_1, 5f);
	// 	//Debug.Log(hit.collider.transform);
	// 	if (hit.collider.tag == "Player"){
	// 		//Debug.Log("Player Sighted");
	// 		parentScript.playerVisible = true;
	// 		if (!parentScript.alerted){
	// 			parentScript.alerted = true;
	// 			parentScript.timeToUnalert = 5f;
	// 		}
	// 	}
	// 	else{
	// 		parentScript.playerVisible = false;
	// 	}
		
	// }

	// void OnTriggerStay2D(Collider2D collider){
	// 	//Debug.Log("Coucou");
	// 	checkPlayerSight();
	// }
}
