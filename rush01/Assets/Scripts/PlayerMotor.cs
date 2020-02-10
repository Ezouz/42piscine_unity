using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    CharacterAnimator characterAnimator;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    void Update()
    {
        if (target != null)
        {
            characterAnimator.Run();
            agent.SetDestination(target.position);
            FaceTarget();
        }
        if (characterAnimator.pathComplete())
        {
            characterAnimator.StopRunning();
            StopFollowingTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        characterAnimator.Run();
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform;

    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 1f;
        agent.updateRotation = true;
        target = null;
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // smoother that just lookRotation
    }


}