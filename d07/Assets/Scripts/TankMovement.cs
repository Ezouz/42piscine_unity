using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed = 8.0f;
    public float maxSpeed = 30.0f;
    public float currentSpeed;

    public bool boost = false;
    public bool max = false;
    public Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // boost
        if (Input.GetKey(KeyCode.LeftShift)) {
            if (!max) {
                currentSpeed += 2.0f;
                boost = true;
            } else {
                // si max - 3sec avant de redescendre
                StartCoroutine("boosting");
            }
        } else {
            boost = false;
        }
        if (!boost) {
            currentSpeed -= 2.0f;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, speed, maxSpeed);
        // Debug.Log(currentSpeed);
        
        if (currentSpeed == maxSpeed && !max) {
            max = true;
            // 3 sec avant de pouvoir le reutiliser
            StartCoroutine("stopBoost");
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(-Vector3.forward * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(new Vector3 (0, -3.0f, 0));
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(new Vector3 (0, 3.0f, 0));
        }
    }

    IEnumerator boosting () {
        yield return new  WaitForSeconds(3.0f);
        boost = false;

    }
    IEnumerator stopBoost () {
        yield return new  WaitForSeconds(3.0f);
        max = false;
    }
}
