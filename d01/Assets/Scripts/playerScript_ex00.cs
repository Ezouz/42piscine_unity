using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour
{
    public bool actif;
    public cam0 mcam;
    public float leftLimit;
    public float rightLimit;
    Rigidbody2D rb;

    void Start()
    {
        if (transform.name == "Thomas0") {
            actif = true;
        }
        mcam = Camera.main.GetComponent<cam0>();
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        // selectionner perso 123
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            if (transform.name == "Thomas0")
                actif = true;
            else
                actif = false;
        } else if (Input.GetKeyDown(KeyCode.Keypad2)) {
            if (transform.name == "John0")
                actif = true;
            else
                actif = false;
        } else if (Input.GetKeyDown(KeyCode.Keypad3)) {
            if (transform.name == "Claire0")
                actif = true;
            else
                actif = false;
        }
        // deplacements
        if (actif)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
            }
            if (Input.GetKey("left"))
            {
                if (transform.position.x >= leftLimit)
                    transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
            }
            if (Input.GetKey("right"))
            {
                if (transform.position.x <= rightLimit)
                    transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
            }
            mcam.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
