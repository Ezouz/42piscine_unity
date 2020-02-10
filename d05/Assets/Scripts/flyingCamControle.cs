using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingCamControle : MonoBehaviour
{
    public float mainSpeed; //regular speed
    float sensitiv; //How sensitive it with mouse
    Vector3 lastMouse; //kind of in the middle of the screen, rather than at the top (play)
    public Vector3 lastPos;
    public bool isLimit = false;

    void Start()
    {
        mainSpeed = 50.0f;
        sensitiv = 0.25f;
        lastMouse = new Vector3(255, 255, 255);
    }
    void Update()
    {
        //Mouse camera angle
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * sensitiv, lastMouse.x * sensitiv, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;

        //Keyboard commands
        Vector3 p = GetBaseInput();
        p = p * Time.deltaTime * mainSpeed;
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.LeftShift)) //If player wants to move on X and Z axis only
        { 
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
            lastPos = newPosition;
        }
        else
        {
            transform.Translate(p);
        }
    }
    private Vector3 GetBaseInput()
    { 
        Vector3 p_Velocity = new Vector3();
        if (transform.position.y < 115f) {
            if (Input.GetKey(KeyCode.E))
                p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.Q))
            p_Velocity += new Vector3(0, -1, 0);
        if (Input.GetKey(KeyCode.W))
            p_Velocity += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.S))
            p_Velocity += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.A))
            p_Velocity += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.D))
            p_Velocity += new Vector3(1, 0, 0);
        return p_Velocity;
    }
}