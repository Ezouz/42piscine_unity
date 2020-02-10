using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{
    public GameObject[] associated;
    public SpriteRenderer init;
    public Color col;
    public bool appear;
    public bool door;
    public bool multi;

    void Start()
    {
        col = init.color;
    }

    void OnTriggerEnter2D(Collider2D col)
    {   
        if (col.transform.name == "Thomas" || col.transform.name == "John" || col.transform.name == "Claire") {
            Color myColor = init.color;
            Color otherColor = col.transform.gameObject.GetComponentInParent<playerScript_ex01>().color;
            bool same = ((int)(myColor.r * 1000) >= (int)(otherColor.r * 1000) - 5 && (int)(myColor.r * 1000) <= (int)(otherColor.r * 1000) + 5); // couleur perso == couleur switch
            foreach (GameObject go in associated)
            {
                if (multi) {
                    init.color = col.transform.gameObject.GetComponentInParent<playerScript_ex01>().color;
                    if (door) {
                        // interrupteur qui ouvre porte selon qui touche
                        Color goColor = go.transform.gameObject.GetComponentInParent<SpriteRenderer>().color;
                        if (((int)(goColor.r * 1000) >= (int)(otherColor.r * 1000) - 5 && (int)(goColor.r * 1000) <= (int)(otherColor.r * 1000) + 5)) {
                            go.transform.localScale = new Vector3(go.transform.localScale.x, 1.0f, go.transform.localScale.z);
                        } 
                    } else {
                    // interrupteur qui change couleur plateform selon qui touche
                        go.transform.gameObject.GetComponentInParent<SpriteRenderer>().color = col.transform.gameObject.GetComponentInParent<playerScript_ex01>().color;
                        if (col.transform.name == "Thomas")
                            go.transform.gameObject.layer = 11;
                        else if (col.transform.name == "John")
                            go.transform.gameObject.layer = 12;
                        else if (col.transform.name == "Claire")
                            go.transform.gameObject.layer = 13;
                    }
                } else {
                    if (door) {
                    // interrupteur qui ouvre porte de couleur definit
                        if(same) {
                            go.transform.localScale = new Vector3(go.transform.localScale.x, 1.0f, go.transform.localScale.z);
                        }
                    } else {
                    // interrupteur qui allume platforme couleur definit
                        if(same) {
                            if (appear) {
                                Debug.Log("Instantiate");
                                Instantiate(go);
                            }
                        }
                    }
                }
            }
        }
    }

    void Update()
    {

    }
}