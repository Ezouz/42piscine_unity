using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public float doorRotateSpeed = 800f;
    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.transform.CompareTag("door_front"))
        {
            obj.transform.parent.Rotate(new Vector3(0f, 0f, 1f) * Time.deltaTime * doorRotateSpeed);
        }
        if (obj.transform.CompareTag("door_back"))
        {
            obj.transform.parent.Rotate(new Vector3(0f, 0f, 1f) * Time.deltaTime * -doorRotateSpeed);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
