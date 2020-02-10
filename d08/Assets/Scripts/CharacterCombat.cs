using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f; // will variate with level
    private float attackCooldown = 0f;
    public float attackDelay = .6f;
    float lastAttackTime;
    const float combatCooldown = 2f; // seconds
    public bool InCombat { get; private set; }
    public bool OnAttack = false;
    CharacterStats myStats;
    CharacterAnimator characterAnimator;
    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (Time.time - lastAttackTime > combatCooldown)
        {
            InCombat = false;
        }
    }

    public void Attack(CharacterStats targetStats)
    {
        if (targetStats.HP > 0) {
            if (!OnAttack) {
                OnAttack = true;
                StartCoroutine(DoDamage(targetStats, attackDelay));
            }
            attackCooldown = 5f / attackSpeed;
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        characterAnimator.Attack();
        yield return new WaitForSeconds(delay);
        OnAttack = false;
        // nik pdt anim
        characterAnimator.StopAttacking();
    }


    public void nik() {
        CharacterStats enemyStats;
        if (transform.name == "Maya") {
            enemyStats = GetComponent<PlayerController>().targetStats;
        } else {
            enemyStats = GetComponent<EnemyController>().targetStats;
        }
        if (enemyStats != null) {
            float distance = Vector3.Distance(enemyStats.transform.position, transform.position);
            if (distance <= 1f)
            {
                int hit = 75 + myStats.agility.GetValue() - enemyStats.agility.GetValue();
                if (Random.Range(0f, 100f) < hit) {
                    // chance de toucher
                    int baseDamage = Random.Range(myStats.minDamage.GetValue(), myStats.maxDamage.GetValue());
                    int finalDamages = baseDamage * (1 - enemyStats.armor.GetValue() / 200);
                    enemyStats.TakeDamage(finalDamages);
                }
            }
        }
    }
}