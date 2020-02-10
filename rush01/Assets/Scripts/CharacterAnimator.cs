using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
	public AudioSource zombie;
    NavMeshAgent agent;
    protected Animator animator;
    const float locomationAnimationSmoothTime = .1f;
    private bool hasPath = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    public bool pathComplete()
    {
        hasPath |= agent.hasPath;
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance + 0.5f) // (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (hasPath)
            {
                hasPath = false;
                agent.velocity = Vector3.zero;
                agent.SetDestination(transform.position);
                return true;
            }
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                return true;
        }
        return false;
    }

    public void Run()
    {
        animator.SetBool("isRunning", true);
    }
    public void StopRunning()
    {
        animator.SetBool("isRunning", false);
    }
    public void Attack()
    {
        animator.SetBool("isAttacking", true);
    }

    public void StopAttacking()
    {
        animator.SetBool("isAttacking", false);
    }

    public void UnDead()
    {
        animator.SetBool("isDead", false);
    }

    public void IsDead()
    {
        zombie.Play();
        Debug.Log("IsDead " + transform.name);
        animator.SetBool("isDead", true);
    }

    void Update()
    {
    }
}
