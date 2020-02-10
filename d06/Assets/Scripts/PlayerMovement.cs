using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 4.0f;
    private CharacterController _charCont;
    public float height;
    public float gravity = -9.8f;
    public bool isCrouching = false;
    public bool isRunning = false;

    void Start()
    {
        _charCont = GetComponent<CharacterController>();
        height = _charCont.height;
    }

    void Update()
    {
        float tmpSpeed = speed;
        // crouch
        if (Input.GetKey(KeyCode.LeftShift)) {
            _charCont.height = height / 5.0f; 
            isCrouching = true;
        } else {
            _charCont.height = height; 
            isCrouching = false;
        }
        // run
        if (Input.GetKey(KeyCode.Space)) {
            if (!isRunning) {
                isRunning = true;
            }
        } else {
            isRunning = false;
        }
        // can be add
        if (isCrouching)
            tmpSpeed -= 2.0f;
        if (isRunning)
            tmpSpeed += 2.0f;
        
        float deltaX = Input.GetAxis("Horizontal") * tmpSpeed;
        float deltaZ = Input.GetAxis("Vertical") * tmpSpeed;
        Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude (movement, tmpSpeed); // limits max speed
        movement.y = gravity;

        movement *= Time.deltaTime; 
        movement = transform.TransformDirection(movement);
        _charCont.Move(movement);
    }
}
