using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public playerScript_ex01 perso;

    void Start()
    {
        perso = GetComponentInParent<playerScript_ex01> ();
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (perso.actif) {
            // Debug.Log(perso.transform.name + " is on " + col.gameObject.name);
            if (col.gameObject.tag == "perso") {
                if (col.gameObject.GetComponentInParent<playerScript_ex01> ().onPlatform) {
                    perso.onPlatform = true;
                    transform.parent.parent = col.transform.parent;
                }
            }
            perso.jumping = false;
        }
    }
      
    void OnCollisionExit2D(Collision2D col)
    {
        if (perso.actif) {
            if (col.gameObject.tag == "perso") {
                if (col.gameObject.GetComponentInParent<playerScript_ex01> ().onPlatform) {
                    perso.onPlatform = false;
                    transform.parent.parent = null;
                }
            }
            // Debug.Log(perso.transform.name + " exit from on " + col.gameObject.name);
            perso.jumping = true;
        }
    }
}
