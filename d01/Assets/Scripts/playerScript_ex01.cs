using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour
{
    public bool actif;
    public bool jumping;
    public bool surrounded;
    public int jumpforce;
    public float speed;
    public cam mcam;
    Rigidbody2D rb;
    public float leftLimit;
    public float rightLimit;
    public bool isReady = false;
    public bool onPlatform = false;
    public Color color;

    void Start()
    {
        if (transform.name == "Thomas") {
            actif = true;
            // color = new Color(0.831f, 0.257f, 0.275f, 1.000f);
            color = new Color(0.830f, 0.273f, 0.273f, 1.000f);
        }
        if (transform.name == "John")
            color = new Color(0.702f, 0.608f, 0.255f, 1.000f);
        if (transform.name == "Claire")
            color = new Color(0.149f, 0.243f, 0.369f, 1.000f);
        mcam = Camera.main.GetComponent<cam>();
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            if (transform.name == "Thomas") {
                actif = true;
                jumping = false;
            } else
                actif = false;
        } else if (Input.GetKeyDown(KeyCode.Keypad2)) {
            if (transform.name == "John") {
                actif = true;
                jumping = false;
            } else
                actif = false;
        } else if (Input.GetKeyDown(KeyCode.Keypad3)) {
            if (transform.name == "Claire") {
                actif = true;
                jumping = false;
            } else
                actif = false;
        } 
        if (actif) {
			rb.mass = 1f;
            // mcam.position = new Vector3(transform.position.x , transform.position.y, transform.position.z);
        } else {
			rb.mass = 500f;
			rb.velocity = (new Vector2 (0, rb.velocity.y));
		}
    }

    void FixedUpdate() {
        if (actif) {
            Vector2 move = rb.velocity;  
            float hor = Input.GetAxis ("Horizontal");  
            if (!((transform.position.x <= leftLimit && hor <= 0) || (transform.position.x >= rightLimit && hor >= 0)))  
                move.x = hor * speed;  
            else  
                move.x = 0f; 
            if (Input.GetKeyDown(KeyCode.Space) && !jumping) {
                move.y = jumpforce;  
            }
            rb.velocity = move;
            mcam.position = new Vector3(transform.position.x , transform.position.y, transform.position.z);
        }
    }

    // void OnTriggerEnter2D(Collider2D col) {
    // }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "platform") {
            transform.parent = col.transform;
            onPlatform = true;
        }
     }
    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "platform") {
            transform.parent = null;
            onPlatform = false;
        }
     }
}
