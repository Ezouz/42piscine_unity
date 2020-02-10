using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Camera mcam;
    public Vector3 position;
    Vector3 initPos;
    Vector3 tPos;
    Vector3 jPos;
    Vector3 cPos;
    
    public GameObject Thomas;
    public GameObject John;
    public GameObject Claire;
    

    void Start()
    {
        mcam = Camera.main;
        mcam.nearClipPlane = -3f;
        initPos = transform.position;
        tPos = Thomas.transform.position;
        jPos = John.transform.position;
        cPos = Claire.transform.position;
    }

    void Update()
    {
        transform.position = position;
        if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = initPos;
            Thomas.transform.position = tPos;
            John.transform.position = jPos;
            Claire.transform.position = cPos;
            Thomas.GetComponent<playerScript_ex01>().actif = true;
            John.GetComponent<playerScript_ex01>().actif = false;
            Claire.GetComponent<playerScript_ex01>().actif = false;
        }
    }
}
