using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapLimits : MonoBehaviour
{
    public GameObject ball;

    void OnTriggerExit(Collider obj) {
        if (obj.transform.name == "Main Camera") {
            GameManager.GM.SetCamInitPos();
        }
        if (obj.transform.name == "golf_ball") {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GameManager.GM.SetBallInitPos();
            // reset compteur
            GameManager.GM.score[GameManager.GM.currentTrou] = 0;
            // normalement penalite -1
        }
    }
    void Start()
    {
    }
    void Update()
    {
    }
}
