using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    public int missiles = 5;
    public int porteeMissiles = 150;
    public int porteeRiffles = 100;
    public GameObject RiffleImpact;
    public GameObject MissileImpact;
    public float cooldown;
    public float t;
    // private bool max = false;
    // private bool reloading = false;

    void Start()
    {
    }

    void Update()
    {
         if (Input.GetMouseButtonDown(0)) { // mitraille
            if (Time.time - t >= cooldown) {
                t = Time.time;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, porteeRiffles))
                {
                    Instantiate(RiffleImpact, hit.point, Quaternion.LookRotation(hit.normal));
                    // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    // Debug.Log("Did Hit");
                    // Debug.Log(hit.transform.name);
                    if (hit.transform.gameObject.tag == "enemy")
                        hit.transform.gameObject.GetComponent<EnemyManager>().PV -= 1;
                }
                GameManager.GM.source.PlayOneShot(GameManager.GM.riffleSound);
            }
        
        }
        if (Input.GetMouseButtonDown(1)) { // missiles
            if (Time.time - t >= cooldown) {
                t = Time.time;
                if (missiles >= 1) {
                    missiles -= 1;
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, porteeMissiles))
                    {
                        Instantiate(MissileImpact, hit.point, Quaternion.LookRotation(hit.normal));
                        // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                        // Debug.Log("Did Hit");
                        // Debug.Log(hit.transform.name);
                        GameManager.GM.source.PlayOneShot(GameManager.GM.missileSoundHit);
                        if (hit.transform.gameObject.tag == "enemy")
                            hit.transform.gameObject.GetComponent<EnemyManager>().PV -= 2;
                        // max = false;
                    } else {
                        GameManager.GM.source.PlayOneShot(GameManager.GM.missileSound);
                    }
                // } else {
                //     if (!max) {
                //         max = true;
                //     }
                }
            }
        }
        // if (max) {
        //     if (!reloading) {     
        //         StartCoroutine("reload");
        //         reloading = true;
        //     }
        // }
    }
    // IEnumerator reload () {
    //     yield return new  WaitForSeconds(5.0f);
    //     missiles = 5;
    //     max = false;
    //     reloading = false;
    // }   
}
