using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject ball;
    public Transform[] depart;
    public Transform[] mc;
    public Transform[] flag;
    public GameObject[] trou;
    public int currentTrou = 0;
    public bool next = false; 
    public bool loadUi = false; 
    public int[] par;
    public int[] score;

    void Awake () {
        if (GM == null) {
            GM = this;
        }
    }

    void Start()
    {
        SetBallInitPos();
        SetCamInitPos();
    }

    public void SetBallInitPos() {
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        generalController.MGC.activateGaugeView(true); // turn off
        ball.transform.position = new Vector3(depart[currentTrou].transform.position.x, depart[currentTrou].transform.position.y, depart[currentTrou].transform.position.z);
        ball.transform.eulerAngles = new Vector3(depart[currentTrou].eulerAngles.x, depart[currentTrou].eulerAngles.y, depart[currentTrou].eulerAngles.z);
    }

    public void SetCamInitPos() {
        if (Camera.main.gameObject.activeInHierarchy) {
            Camera.main.transform.position = new Vector3(mc[currentTrou].transform.position.x, mc[currentTrou].transform.position.y, mc[currentTrou].transform.position.z);
            Camera.main.transform.eulerAngles = new Vector3(mc[currentTrou].eulerAngles.x, mc[currentTrou].eulerAngles.y, mc[currentTrou].eulerAngles.z);
        }
    }

    void Update()
    {
        if (loadUi) {
            if (currentTrou <= 3) {
                if (currentTrou - 1 >= 0)
                    transform.GetComponent<scoreUi>().displayScoreTrou(currentTrou - 1);
            } 
            loadUi = false;
        }
        if (currentTrou <= 2) {
            if (next) {
                if (Input.GetKey(KeyCode.Return)) {
                    next = false; 
                    SetBallInitPos();
                }
            }
        }
        if (Input.GetKeyDown("r")) {
            next = false; 
            SetBallInitPos();
        }

        
    }
}
