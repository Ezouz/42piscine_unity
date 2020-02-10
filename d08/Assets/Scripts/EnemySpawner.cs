using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject clone;
    float t;
    float cooldown;
    bool isDead = false;

    void Start()
    {
        t = Time.time;
        spawnOne();
    }

    void Update()
    {
        if (clone == null) {
            if (!isDead) {
                cooldown = Random.Range(3.0f, 6.0f);
                isDead = true;
            }
            if (Time.time - t >= cooldown) {
                t = Time.time;
                spawnOne();
                isDead = false;
            }
        }
    }

    void spawnOne () {
        clone = Instantiate(enemy[Random.Range(0, 2)], transform);
        clone.transform.parent = gameObject.transform;
    }
}
