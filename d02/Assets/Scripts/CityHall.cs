using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityHall : MonoBehaviour
{
    public Transform[] prefabs;
    float t;
    public float spawnTime = 10f;

    void Start()
    {
        t = Time.time;
    }

    void Update()
    {
        if (Time.time - t >= spawnTime) {
            for (int i = 0; i < prefabs.Length; i++)
            {
                Instantiate(prefabs[i]);
            }
            t = Time.time;
        }
    }


}
