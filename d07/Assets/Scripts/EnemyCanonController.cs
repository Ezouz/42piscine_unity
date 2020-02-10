using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanonController : MonoBehaviour
{
    public int[] portee;
    public GameObject[] Impact;
    public bool fire;
    public int type;

    void Update()
    {
        if (fire) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, portee[type]))
            {
                // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                // Debug.Log("Did Hit");
                // Debug.Log(hit.transform.name);
                Instantiate(Impact[type], hit.point, Quaternion.LookRotation(hit.normal));
                if (type == 1) // missiles
                    GameManager.GM.source.PlayOneShot(GameManager.GM.missileSoundHit);
                else
                    GameManager.GM.source.PlayOneShot(GameManager.GM.riffleSound);
                if (hit.transform.gameObject.tag == "player") {
                    PlayerManager.PM.PV -= 1;
                } else if (hit.transform.gameObject.tag == "enemy") {
                    hit.transform.gameObject.GetComponent<EnemyManager>().PV -= 1;
                }
            } else {
                if (type == 1) // missiles
                    GameManager.GM.source.PlayOneShot(GameManager.GM.missileSound);
                else
                    GameManager.GM.source.PlayOneShot(GameManager.GM.riffleSound);
            }
            fire = false;
        }
    }
}
