using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public LayerMask mvtMask;
    PlayerMotor motor;
    public Interactable focus;
    CharacterCombat combat;
    public CharacterStats targetStats;
    public bool itsAmove = false;
    public bool itsAnAttack = false;
    float t;
    bool pressing = false;
    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        combat = GetComponent<CharacterCombat>();
    }
    void Update()
    {
        // if inventory is open
        // if (EventSystem.current.IsPointerOverGameObject())
        // return;
        if (Input.GetMouseButton(0))
        {
            if (!pressing) {
                pressing = true;
                t = Time.time;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Time.time - t >= 0.15f) {
                itsAnAttack = true;
            } else {
                itsAmove = true;
            }
            pressing = false;
        }
        if (itsAmove || itsAnAttack) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (itsAmove) {
                    // move agent
                    motor.MoveToPoint(hit.point);
                    // removeFocus
                    RemoveFocus();
                    itsAmove = false;
                } else if (itsAnAttack) {
                    // check for interaction
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                    itsAnAttack = false;
                }
            }
        }
        if (focus != null) {
            // if tag enemy 
            if (focus.transform.tag == "enemy") {
                // if in range
                float distance = Vector3.Distance(focus.transform.position, transform.position);
                if (distance <= 1f) {
                    targetStats = focus.transform.gameObject.GetComponent<CharacterStats>();
                    motor.target = focus.transform;
                    motor.FaceTarget();
                    combat.Attack(targetStats);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;

        motor.StopFollowingTarget();
    }
}

//function ProximityCheck()
//{
//    for (int i = 0; i < enemies.Length; i++)
//    {
//        if (Vector3.Distance(transform.position, enemies[i].transform.position) < dangerDistance)
//        {
//            return true;
//        }
//    }
//    return false;
//}
//IEnumerator DoCheck()
//{
//    for (; ; )
//    {
//        ProximityCheck;
//        yield return new WaitForSeconds(.1f);
//   }
//}