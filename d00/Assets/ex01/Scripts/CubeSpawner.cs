using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Transform[] prefabs;
    public Transform[] keys;
    float t;
    
    void Start()
    {
        t = Time.time;
    }

    void Update()
    {
        if (Time.time - t >= 0.5f) {
            int type = Random.Range(0, 3);
            if (!keys[type]) {
                keys[type] = Instantiate(prefabs[type]);
            }
            t = Time.time;
        }
    }
}
