using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitCheck : MonoBehaviour
{
    public string exit4;
    void OnTriggerEnter2D(Collider2D col)
    {
    }

    void OnTriggerStay2D(Collider2D col) 
    {
        if (col.transform.name == "Thomas" || col.transform.name == "John" || col.transform.name == "Claire") {
            float mt = transform.position.y + 0.15f;
            float mb = transform.position.y - 0.15f;
            float ml = transform.position.x - 0.15f;
            float mr = transform.position.x + 0.15f;

            if ((col.transform.position.y <= mt && col.transform.position.x <= mr && col.transform.position.x >= ml) || // h g d
                (col.transform.position.y >= mb && col.transform.position.x <= mr && col.transform.position.x >= ml)) {
                if (col.transform.name == exit4) {
                    // Debug.Log(col.transform.name + " EST READY");
                    GameManager.instance.playerInZone = col.transform.name;
                    GameManager.instance.inZone = true;
                }
            } else {
                if (col.transform.name == exit4) {
                    // Debug.Log(col.transform.name + " NOT READY");
                    GameManager.instance.playerInZone = col.transform.name;
                    GameManager.instance.inZone = false;
                }
            }
        }
    }
}
