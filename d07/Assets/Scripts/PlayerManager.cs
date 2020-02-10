using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager PM;
    public GameObject Clone;
    public Transform start;
    public bool reborn = false;

    public int PV = 5;

    void Awake () {
        if (PM == null) {
            PM = this;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R)) {
            Clone.transform.rotation = Quaternion.Euler(new Vector3(Clone.transform.eulerAngles.x, Clone.transform.eulerAngles.y, 0));
        }
        if (Input.GetKey(KeyCode.T)) {
            reset();
        }
        if (PV <= 0) {
            reset();
        } else {
            if (reborn)
                reborn = false;
        }
    }
    void reset () {
        if (!reborn) {
            Clone.transform.position = start.position;
            PV = 5;
            reborn = true;
        }
    }
}
