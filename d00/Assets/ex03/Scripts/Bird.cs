using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Debug.Log, Input.GetKeyDown, Transform.Rotate, Transform.Translate, Mathf.RoundToInt
public class Bird : MonoBehaviour
{
	public GameObject pipe;
	private bool play = true;

	void Start () {
	
	}
	
	void Update () {
		if (play) {
			if (Input.GetKeyDown ("space"))
				transform.Translate (new Vector3 (0f, 1f, 0f));
			else 
				transform.Translate (new Vector3 (0f, -0.05f, 0f));
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
        play = false;
	}
}
