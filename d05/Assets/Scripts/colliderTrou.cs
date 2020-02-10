using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderTrou : MonoBehaviour
{
    void OnTriggerEnter(Collider obj) {
        if (obj.transform.name == "golf_ball") {
            if (transform.name == "trou1" && GameManager.GM.currentTrou == 0) {
                winwin();
            } else if (transform.name == "trou2" && GameManager.GM.currentTrou == 1) {
                winwin();
            } else if (transform.name == "trou3" && GameManager.GM.currentTrou == 2) {
                winwin();
            } else {
                Debug.Log("WRONG HOLE");
            }
        }
    }

    void winwin() {
        if (GameManager.GM.currentTrou < 3) {
            GameManager.GM.currentTrou += 1;
            GameManager.GM.next = true;
            GameManager.GM.loadUi = true;
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
