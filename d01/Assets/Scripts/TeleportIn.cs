using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportIn : MonoBehaviour
{
    public Transform Out;

    void OnTriggerEnter2D(Collider2D col) {
        col.transform.position = Out.position;
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
