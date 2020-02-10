using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Debug.Log, Mathf.RoundToInt, Input.GetKeyDown, GameObject.Destroy
public class Balloon : MonoBehaviour
{
    public float maxSize = 10.0f;
    private bool breath = false;
    private double startTime = .0;
    private double blockTime = .0;
    private int nbInput = 0;

    void Start()
    {
    }

    void Update()
    {
        float add = -0.05f;
        double durTime = Time.time - startTime;
        double blocked = Time.time - blockTime;

        if (!breath) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                add += 1.0f;
                if (nbInput == 0) {
                    startTime = Time.time;
                }

                if (durTime < 1.0) {
                    nbInput += 1;
                } else {
                    nbInput = 0;
                }
                if (nbInput >= 5) {
                    breath = true;
                    blockTime = Time.time;
                }
            }
        } else {
            // deblock condition
            if (blocked >= 1.0) {
                breath = false;
            }
        }
        // add add
        if (transform.localScale.x > 0.2 && transform.localScale.y > 0.2) {
            transform.localScale += new Vector3(add, add, 0);
        } 
        // here it is blocked to 0.2 because no time to grow back again
        if (transform.localScale.x > 10) {
                Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
                GameObject.Destroy(gameObject);
        }
    }
}
