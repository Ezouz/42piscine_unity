using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName = "";
    public string type = "";

    public bool armeBlanche = false;
    public int ammo;
    public float speed;
    public float distance;
    // public float shotFreq;
    public GameObject toBody;
    public bool throwAway = false;
    public Vector3 direction;
    private Vector3 initPos;

    void Start () {
        initPos = transform.position;
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (new Vector3(target.x, target.y, -0.05f) - new Vector3(transform.position.x, transform.position.y, -0.05f)).normalized;
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "enemy")
        {
            Debug.Log(throwAway + obj.transform.name);
            if (armeBlanche) {
                // TO DO CHANGE WITH ENEMY SCRIPT
                obj.transform.GetComponent<enemyScript>().PV -= 1;
                } else {
                // assome
                obj.transform.GetComponent<enemyScript>().dizzy = 5.0f;
            }
        }
        if (obj.tag != "player")
            throwAway = false;
    }
    void Update () {
        if (throwAway) {
            if (Vector3.Distance(initPos, transform.position) <= distance){
                transform.Translate(direction * speed * Time.deltaTime);
            }  
            else {
                throwAway = false;
            }
        }
    }

}
