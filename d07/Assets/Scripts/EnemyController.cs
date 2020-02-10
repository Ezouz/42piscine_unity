using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float enemyRadius = 400f;
    public Transform Target;
    public Transform Other;
    public Transform targeting;
    public NavMeshAgent agent;
    public GameObject canon;
    public float cooldown;
    public float t;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Target = PlayerManager.PM.Clone.transform;
    }

    void Update()
    {
        float distance = 0f;
        
        if (Target == null && Other == null) {
            targeting = null;
        } else if (Target == null && Other != null) {
            distance = Vector3.Distance(Other.position, transform.position);
            targeting = Other;
        } else if (Target != null && Other == null) {
            distance = Vector3.Distance(Target.position, transform.position);
            targeting = Target;
        } else {
            float distanceTarget = Vector3.Distance(Target.position, transform.position);
            float distanceOther = Vector3.Distance(Other.position, transform.position);
            targeting = distanceTarget < distanceOther ? Target : Other;
            distance = distanceTarget < distanceOther ? distanceTarget : distanceOther;
        }
        
        if (targeting != null) {
            if (distance <= enemyRadius) {
            // choose who to attack 
                if (distance <= lookRadius) {
                    agent.SetDestination(targeting.position);
                }
                if (distance <= agent.stoppingDistance) {
                    FaceTarget();
                    AttackTarget();
                }
            }
        }
    }

    void FaceTarget () {
        Vector3 direction = (targeting.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = LookRotation;
        canon.transform.rotation = LookRotation;
    }

    void AttackTarget() {
        if (Time.time - t >= cooldown) {
            t = Time.time;
            canon.GetComponent<EnemyCanonController>().type = Random.Range(1, 2);
            canon.GetComponent<EnemyCanonController>().fire = true;
            cooldown = Random.Range(0.1f, 2.0f);
        }
    }

    public void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
