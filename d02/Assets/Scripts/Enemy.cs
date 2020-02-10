using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int direction = 0;
    public float speed = 0;
    public bool moveOrder = false;
    public bool moving = false;
    public Animator anim;
    public Vector3 targetPosition;
    public GameObject[] targets;
    // public AudioClip[] acknowledge;
    // public AudioClip[] selected;
    // public AudioClip[] annoyed;
    // public AudioClip[] help;
    public AudioClip dead;
    public AudioSource source;
    public bool attack = false;
    public bool attacking = false;
    public GameObject enemy;
    public float t;
    // public int PV = 3;

    void Awake () 
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // choisir cible si HCH go
        // si croise team go
        // si OCH under attack go
    }

    void calculateCoef () {
        Vector3 coef = targetPosition - transform.position;
        float rot = 0;
        
        if (coef.x == 0 && coef.y > 0) { //  haut
            direction = 0;
            rot = 0;
        } else if (coef.x > 0 && coef.y > 0) { //  haut droite
            direction = 1;
            rot = 0;
        } else if (coef.x > 0 && coef.y == 0) { //  droite
            direction = 2;
            rot = 0;
        } else if (coef.x > 0 && coef.y < 0) { //  bas droite
            direction = 3;
            rot = 0;
        } else if (coef.x == 0 && coef.y < 0) { //  bas
            direction = 4;
            rot = 0;
        } else if (coef.x < 0 && coef.y < 0) { //  bas gauche 
            direction = 3;
            rot = 180;
        } else if (coef.x < 0 && coef.y == 0) { //  gauche 
            direction = 2;
            rot = 180;
        } else if (coef.x < 0 && coef.y > 0) { //  haut gauche
            direction = 1;
            rot = 180;
        }
        anim.SetInteger("direction", direction);
        transform.localRotation = Quaternion.Euler(0, rot, 0);
    }

}
