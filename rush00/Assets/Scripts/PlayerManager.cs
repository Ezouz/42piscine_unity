using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int PV = 1;
    public bool dead = false;
    float t;
    float empty = 0.3f;
    public GameObject weaponToBody;
    public bool isArmed = false;
    public AudioSource source;
    public AudioClip Eject;
    public AudioClip DryFire;
    public AudioClip Reload;
    public AudioClip[] Die;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        // tirer click gauche
        if (Input.GetMouseButton(0))
        {
            if (isArmed)
            {
                if (weaponToBody.GetComponent<Weapon2body>().ammo > 0 || weaponToBody.GetComponent<Weapon2body>().armeBlanche) {
                    if (weaponToBody.GetComponent<Weapon2body>().weaponName == "Shotgun") {
                        Debug.Log("shotgun");
                        if ((Time.time - t) >= 0.5) {
                            source.PlayOneShot(Reload, 1f);
                        }
                    }
                    if ((Time.time - t) >= weaponToBody.GetComponent<Weapon2body>().shotFreq) {
                        t = Time.time;
                        weaponToBody.GetComponent<Weapon2body>().fire = true;
                        weaponToBody.GetComponent<Weapon2body>().playerRotation = transform.localRotation.eulerAngles;
                    }
                } else if (weaponToBody.GetComponent<Weapon2body>().ammo <= 0 && (Time.time - t) >= empty) {
                    t = Time.time;
                    source.PlayOneShot(DryFire, 1f);
                }
            }
        } 
        // drop arme click droit
        if (Input.GetMouseButton(1))
        {
            if (isArmed) {
                GameObject tmp = Instantiate(weaponToBody.GetComponent<Weapon2body>().prefab);
                tmp.transform.position = transform.position;
                tmp.GetComponent<Weapon>().ammo = weaponToBody.GetComponent<Weapon2body>().ammo;
                tmp.GetComponent<Weapon>().distance = weaponToBody.GetComponent<Weapon2body>().distance;
                tmp.GetComponent<Weapon>().throwAway = true;
                Destroy(weaponToBody.gameObject);
                isArmed = false;
                source.PlayOneShot(Eject, 1f);
                GameGUI.GGUI.CurrentWeapon = null;
            }
        }
        if (PV <= 0) {
            if (!dead) {
                source.PlayOneShot(Die[Random.Range(0, 4)], 1f);
                dead = true;
            }
        }
    }
}
