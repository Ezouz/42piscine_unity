using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Debug.Log, Mathf.Clamp, Transform.Translate, Input.GetKey
public class Ball : MonoBehaviour
{
    public Transform club;
    float lastPos;
    bool moving = false;
    float speed = 0.0f;
    bool direction = false;
    bool above = false;
    bool setWin = false;
    Vector3 blockPos;
    Vector3 initPos;
    int cpt = 0;

    void Start()
    {
        lastPos = 0;
        initPos = club.transform.position;
        direction = (transform.position.y > 6.90f) ? true : false;
    }

    void Update()
    {
        // speed au dessus du trou !
        if (lastPos == transform.position.y) {
            moving = false;
        }
        if (transform.position.y != lastPos && !moving && !setWin && lastPos != 0) {
            Debug.Log("Score: " + (-15 + (cpt * 5)));
            cpt += 1;
            moving = true;
            direction = (transform.position.y > 6.90f) ? true : false;
        }
        float abs = Mathf.Clamp(transform.position.y, 0.0f, 7.45f);
        if (abs == 0.0f || abs == 7.45f) {
            direction = !direction;
        }
        if (transform.position.y >= 6.50f && transform.position.y <= 6.80f && !above && moving) {
            above = true;
            speed = direction ? lastPos - transform.position.y : transform.position.y - lastPos;
            // tombe dans le trou
            if (speed <= 0.1f) {
                setWin = true;
                transform.Translate(new Vector3(0.0f, 0.0f, 3.0f));
                blockPos = transform.position;
            }
        } else {
            above = false;
        }
        lastPos = transform.position.y;
        if (setWin) {
            club.transform.position = initPos;
            transform.position = blockPos;
        }
    }
}
