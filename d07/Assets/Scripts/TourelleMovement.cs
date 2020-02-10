using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleMovement : MonoBehaviour
{
    public float sensHorizontal = 10.0f;

    void Update()
    {
        transform.Rotate (0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(new Vector3 (0, 3.0f, 0));
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(new Vector3 (0, -3.0f, 0));
        }
    }
}
