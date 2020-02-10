using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour
{
    public int PV;
    private int pvc;
    public bool CH;
    public bool Unit;
    public float t;

    void Start()
    {
        pvc = PV;
    }

    void Update()
    {
        if (PV != pvc) {
            pvc = PV;
            int left = PV * (CH ? 10 : 20);
            if (Unit || CH) {
                if (transform.gameObject.tag == "team")
                    Debug.Log("Human Unit [" + left + "/100]HP has been attacked.");
                else if (transform.gameObject.tag == "orc")
                    Debug.Log("Orc Unit [" + left + "/100]HP has been attacked.");
            }
        }
        if (PV <= 0) {
            if (Unit || CH) {
                if (transform.gameObject.tag == "team") {
                    GameManager.instance.HcityHall.spawnTime += 2.5f;
                    if (CH)
                        GameManager.instance.HCH = false;
                }
                else if (transform.gameObject.tag == "orc") {
                    GameManager.instance.OcityHall.spawnTime += 2.5f;
                    if (CH)
                        GameManager.instance.OCH = false;
                }
            }
            if (!CH && !Unit) {
                // play sound
                if (transform.gameObject.tag == "team") {
                    PlayerMovement script = transform.gameObject.GetComponent<PlayerMovement>();
                    script.source.PlayOneShot(script.dead, 1f);
                    script.anim.SetBool("dead", true);
                } else {
                    Enemy script = transform.gameObject.GetComponent<Enemy>();
                    script.source.PlayOneShot(script.dead, 1f);
                    script.anim.SetBool("dead", true);
                }
            }
            IEnumerator wait = wait4death(3f);
            StartCoroutine(wait);
        }
    }
    IEnumerator wait4death (float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(transform.gameObject);
    }
}
