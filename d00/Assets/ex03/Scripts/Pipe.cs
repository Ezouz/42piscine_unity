using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
	private bool play = true;
	public GameObject pipe;
	public float speed = 0;
	public int score = 0;
    private bool pass = false;

	void Start () {
	}

	void Update () {
		if (play) {
			pipe.transform.Translate (new Vector3 (-0.1f - speed, 0f, 0f));
			if (pipe.transform.position.x < -1.67 && !pass) {
				score += 5;
				speed += 0.01f;
                pass = true;
            }
			if (pipe.transform.position.x < -7.68)
			{
                pass = false;
				pipe.transform.position = new Vector3 (7.66f, pipe.transform.position.y, pipe.transform.position.z);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log ("Score: " + score);
        Debug.Log ("Time: "+ Mathf.RoundToInt(Time.time) + "s");
        play = false;
	}
}
