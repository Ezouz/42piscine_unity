using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)  {
    }

    void OnTriggerStay(Collider obj)  {
                // Debug.Log(obj.tag);
        if (obj.gameObject.layer != 11) {
            if (Input.GetKey(KeyCode.E)) {
                // if (obj.tag == "door") {
                //     obj.GetComponent<Door>().isOpen = !obj.GetComponent<Door>().isOpen;
                // }
                // else 
                if (obj.tag == "key") {
                    GameManager.GM.hasKey = true;
                    obj.gameObject.SetActive(false);
                }
                else if (obj.tag == "cardstuf") {
                    if (GameManager.GM.hasKey) {
                        GameManager.GM.openLaser = true;
                    }
                }
                else if (obj.tag == "paper") {
                    GameManager.GM.hasPaper = true;
                    obj.gameObject.SetActive(false);
                }

            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
