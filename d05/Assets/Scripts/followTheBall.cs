using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTheBall : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public Vector3 moveArround;
    // float speed = 200f;
    Vector3 target;

    void Start()
    {
        transform.position = generalController.MGC.pivot.transform.position - new Vector3(x, y, z);
    }

    public void setMvt(Vector3 mvt)
    {
        moveArround = mvt;
    }
    
    private void OnEnable()
    {
        generalController.MGC.activateGaugeView(true);
    }

    private void OnDisable()
    {
        generalController.MGC.activateGaugeView(false);
        generalController.MGC.activateGauge(false);
        generalController.MGC.pivot.transform.GetChild(0).gameObject.SetActive(false);
    }

    void Update()
    {
        // move pivot
        generalController.MGC.pivot.transform.Rotate(moveArround, Space.World);
        moveArround = Vector3.zero;
    }

    void LateUpdate()
    {
        generalController.MGC.pivot.transform.position = generalController.MGC.ball.transform.position;
    }

}