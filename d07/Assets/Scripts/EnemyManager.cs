using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int PV = 5;

    void Update()
    {
        if (PV <= 0) {
            Destroy(transform.gameObject);
        }
    }
}
