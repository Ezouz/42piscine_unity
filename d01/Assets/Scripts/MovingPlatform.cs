using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float lim1; // gauche ou bas
    public float lim2; // droite ou haut
    public bool isHor;
    public bool tictac;
    public float speed = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        if (isHor) {
            if (!tictac && transform.position.x <= lim1)
                tictac = true;
            if (tictac && transform.position.x >= lim2)
                tictac = false;
            if (tictac)
                transform.Translate(new Vector3(0.1f * speed, 0.0f, 0.0f));
            else
                transform.Translate(new Vector3(-0.1f * speed, 0.0f, 0.0f));
        } else {
            if (!tictac && transform.position.y <= lim1)
                tictac = true;
            if (tictac && transform.position.y >= lim2)
                tictac = false;
            if (tictac)
                transform.Translate(new Vector3(0.0f, 0.1f * speed, 0.0f));
            else 
                transform.Translate(new Vector3(0.0f, -0.1f * speed, 0.0f));
        }
        
    }
    void OnTriggerEnter2D(Collider2D col) {
       
    }

}
