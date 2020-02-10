using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    CharacterAnimator characterAnimator;
    public CharacterStats targetStats;
    public bool isDead = false;
    public float burrySpeed = 0.1f;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    void Update()
    {
        if (isDead)
        {
            Invoke("burryMe", 2f);
            agent.enabled = false;
        } else {
            // movement while not trying to kill player
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                characterAnimator.Run();
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    characterAnimator.StopRunning();
                    // attack target
                    targetStats = target.GetComponent<CharacterStats>();
                    if (targetStats != null)
                    {
                        // face target
                        FaceTarget();
                        combat.Attack(targetStats);
                    }
                }
            }
        }
    }
    
    void burryMe() {
        transform.Translate(Vector3.down * Time.deltaTime * burrySpeed, Space.World);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // smoother that just lookRotation
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawIcon(transform.position, "enemy", true);
    }
}