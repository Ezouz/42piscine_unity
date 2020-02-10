using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2body : MonoBehaviour
{
    public string weaponName = "";
    public string type = "";
    public bool armeBlanche = false;
    public bool tranch = false;
    public float slash = 0f;
    public int ammo;
    public float speed;
    public float shotFreq;
    public float distance;
    public GameObject prefab;
    public GameObject projectile;
    public Vector3 playerRotation;
    private Color effect;
    public bool fire = false;
    float t;
    private AudioSource source;
    public AudioClip Fire;

    void Start()
    {
        source = GetComponent<AudioSource>();
        effect = transform.GetComponent<SpriteRenderer>().color;
    }
    void Update()
    {
        if (fire)
        {
            GameObject proj = Instantiate(projectile);
            proj.transform.position = transform.position;
            proj.GetComponent<Projectile>().speed = speed;
            proj.GetComponent<Projectile>().slash = slash;
            proj.GetComponent<Projectile>().playerRotation = playerRotation;
            if (armeBlanche) {
                effect.a = 0f;
                transform.GetComponent<SpriteRenderer>().color = effect;
                t = Time.time;
                tranch = true;
            }
            ammo -= 1;
            fire = false;
            source.PlayOneShot(Fire, 1f);
        }
        if (tranch) {
            if ((Time.time - t) >= slash) {
                effect.a = 1f;
                transform.GetComponent<SpriteRenderer>().color = effect;
                tranch = false;
            }
        }

    }
}
