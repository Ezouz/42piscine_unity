using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    public Transform ball;
    public Vector3 clubPos;
    float value = 0.0f;
    float force = 0.0f;
    bool load = false;
    bool shot = false;
    double impact = 0;
    bool direction; // true vers le bas
    bool rolling = false;

    void Start()
    {
        clubPos = transform.position;
        clubDirection();
    }

    void clubDirection () {
        Vector3 tmp;
        tmp = ball.transform.position;
        if (ball.transform.position.y > 6.90f) { // haut du trou
            direction = true;
            transform.eulerAngles = new Vector3(-180, 0, 0);
            tmp += new Vector3(-0.3f, 0.05f , 0.0f);
        } else {
            direction = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
            tmp -= new Vector3(0.3f, 0.05f , 0.0f);
        }
        transform.position = tmp;
    }

    void Update()
    {
        if (Input.GetKey("space")) {
            force += 0.015f;
            transform.Translate(new Vector3(0.0f, -force, 0.0f));
        } else {
            if (force > 0 && value != force) {
                value = force;
                load = true;
            } else {
                if (load) {
                    shot = true;
                    transform.position = clubPos;
                    load = false;
                }
                // make the ball roll - impulsion
                if (shot) {
                    if (impact == 0) {
                        impact = Time.time;
                        rolling = true;
                    }
                    if (rolling) {
                        ball.transform.Translate(new Vector3(0.0f, (direction ? 0.01f - force : 0.01f + force), 0.0f));
                        // check borders
                        float abs = Mathf.Clamp(ball.transform.position.y, 0.0f, 7.45f);
                        if (abs == 0.0f || abs == 7.45f) {
                            direction = !direction;
                        }
                        force -= 0.01f;
                        value -= 0.01f;
                    }
                    if (force < 0.0f) {
                        clubPos = transform.position;
                        shot = false;
                        rolling = false;
                        impact = 0;
                        force = 0.0f;
                        clubDirection();
                    }
                }
            }
        }
    }
}
