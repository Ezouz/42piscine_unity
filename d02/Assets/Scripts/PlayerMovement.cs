using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public Vector3 targetPosition;
    public bool moveOrder = false;
    public bool moving = false;
    public bool inTeam = false;
    public int direction = 0;
    // public int PV = 3;
    public Animator anim;
    public AudioClip[] acknowledge;
    public AudioClip[] selected;
    public AudioClip[] annoyed;
    public AudioClip[] help;
    public AudioClip dead;
    public AudioSource source;
    public bool attack = false;
    public bool attacking = false;
    public GameObject enemy;
    public float t;

    void Awake () 
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        t = Time.time;
        anim = GetComponent<Animator>();
    }

    // calcul direction
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

    void Update()
    {   if (inTeam) {
            source.PlayOneShot(selected[Random.Range(0, 6)], 1f);
            inTeam = false;
        }
        if (moveOrder) {
            calculateCoef();
            anim.SetBool("moving", true);
            source.PlayOneShot(acknowledge[Random.Range(0, 4)], 1f);
            moving = true;
            moveOrder = false; 
        }
        if (moving) {
            targetPosition = new Vector3(targetPosition.x, targetPosition.y, 0f);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
        if (transform.position == targetPosition) {
            anim.SetBool("moving", false);
            moving = false;
        }
        if (attack) {
            attack = false;
            attacking = true;
            anim.SetBool("attacking", true);
            source.PlayOneShot(annoyed[1], 1f);
        }
        if (enemy != null) {
            targetPosition = enemy.transform.position;
            if (attacking) {
                if (Time.time - t >= 5f)
                {
                    enemy.GetComponent<Damages>().PV -= 1;
                    t = Time.time;
                }
                if (enemy.GetComponent<Damages>().PV <= 0)
                {
                    enemy = null;
                    attacking = false;
                    anim.SetBool("attacking", false);
                    targetPosition = transform.position;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (transform.tag != col.transform.tag && col.transform.gameObject.layer != 8)
        {
            if (col.transform.gameObject.tag != "team") {
                enemy = col.transform.gameObject;
                attack = true;
            }
            if (col.transform.gameObject.GetComponent<Damages>().PV <= 0)
            {
                attacking = false;
                enemy = null;
                anim.SetBool("attacking", false);
            }
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (transform.tag != col.transform.tag && col.transform.gameObject.layer != 8)
        {
            if (enemy) {
                moving = true;
            } else {
                if (col.transform.gameObject.tag != "team")
                {
                    attacking = false;
                    enemy = null;
                    anim.SetBool("attacking", false);
                }
            }
        }
    }
}
