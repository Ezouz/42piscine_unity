using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playThisBall : MonoBehaviour
{
    Rigidbody ball;
    followTheBall fb;
    float speed = 200f;
    public int shotSpeed;
    private float t;
    private bool wasMoving = false;
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        fb = generalController.MGC.cameras[1].GetComponent<followTheBall>();
    }

    void Update()
    {
        if (!GameManager.GM.next) {
            if (ball.velocity.magnitude < 0.2f) {
                ball.velocity = Vector3.zero;
                ball.angularVelocity = Vector3.zero;
                if (wasMoving != generalController.MGC.ballIsRolling && !generalController.MGC.ballIsRolling) {
                    // aligner
                    generalController.MGC.AlignView();
                    wasMoving = generalController.MGC.ballIsRolling;
                }
                generalController.MGC.ballIsRolling = false;
                if (!GameManager.GM.next) {
                    generalController.MGC.activateGaugeView(true); // turn off
                }
            } else {
                generalController.MGC.ballIsRolling = true;
                wasMoving = true;
            }

            // arrow movement around y axis for direction
            fb.setMvt(new Vector3(0, Input.GetAxis("Horizontal"), 0) * Time.deltaTime * speed);

            // gauge handling
            if (Input.GetKey(KeyCode.Space)) {
                if (Time.time - t >= 0.2f) {
                    t = Time.time;
                    if (generalController.MGC.cameraView == 1 
                        && !generalController.MGC.ballIsRolling 
                        && !generalController.MGC.spacePressed
                        && generalController.MGC.isGaugeOn) {
                            kickTheBall();
                    }
                    if (!generalController.MGC.isGaugeOn 
                        && !generalController.MGC.spacePressed
                        && !generalController.MGC.ballIsRolling) {
                            generalController.MGC.activateGauge(true);
                    }
                    else if (generalController.MGC.cameraView == 1)
                        generalController.MGC.spacePressed = false;
                }
            }
        }
    }

    void kickTheBall()
    {
        generalController.MGC.activateGaugeView(false); // turn off
        generalController.MGC.activateGauge(false); // turn off
        ball.AddForce((generalController.MGC.pivot.transform.forward + new Vector3(0,.3f,0)) * generalController.MGC.force * shotSpeed);
        generalController.MGC.ballIsRolling = true;
        if (!GameManager.GM.next) {
            GameManager.GM.score[GameManager.GM.currentTrou] += 1;
        }
    }
}