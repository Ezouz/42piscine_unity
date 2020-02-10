using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool armeBlanche = false;
    public float slash;
    float t;
    public bool destroy = false;
    public float speed;
    public Vector2 target;
    public Vector2 direction;
    public Vector3 playerRotation;
    private AudioSource source;
    public AudioClip Hit;

    void Start()
    {
        source = GetComponent<AudioSource>();
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        transform.Rotate(new Vector3(0, 0, 270 + playerRotation.z), Space.Self);
        direction = (target - new Vector2(transform.position.x, transform.position.y)).normalized;
        direction = Quaternion.AngleAxis(-playerRotation.z, Vector3.forward) * direction;
        direction = (Vector2.Perpendicular(direction)).normalized;
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag != "player") {
            if (obj.tag == "enemy") {
                obj.transform.GetComponent<enemyScript>().PV -= 1;
                source.PlayOneShot(Hit, 1f);
            }
            Destroy(transform.gameObject);
        }
    }
    void Update() {
        if (!armeBlanche) {
            transform.Translate(direction * speed * Time.deltaTime);
        } else {
            if (!destroy) {
                if ((Time.time - t) >= slash)
                {
                    t = Time.time;
                    transform.position += new Vector3(direction.x, direction.y, 0f) * speed * Time.deltaTime;
                    destroy = true;
                }
            }
            if (destroy) {
                if ((Time.time - t) >= slash)
                {
                    Destroy(transform.gameObject);
                    destroy = false;
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (!armeBlanche)
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + direction * speed * Time.fixedDeltaTime);
        }
    }
}
