using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    // public

    void Start()
    {
        
    }

    void Update()
    {
        if (isOpen) {
            StartCoroutine("openDoor");
        }
        // else {
        //     StopCoroutine("openDoor");
        //     StartCoroutine("closeDoor");
        // }
    }
    IEnumerator openDoor () {
        Debug.Log("openDoor");
        yield return new WaitForSeconds(1f);
    }

    IEnumerator closeDoor () {
        Debug.Log("closeDoor");
        yield return new WaitForSeconds(1f);
    }
}
