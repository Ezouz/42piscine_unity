using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
	public AudioSource punch;
    private float attackCooldown = 0f;
    public float attackDelay = .6f;
    float lastAttackTime;
    const float combatCooldown = 0f; // seconds
    public bool InCombat { get; private set; }
    public bool OnAttack = false;
    private bool up;
    CharacterStats myStats;
    CharacterAnimator characterAnimator;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    public void Attack(CharacterStats targetStats)
    {
        if (targetStats.HP > 0) {
            if (!OnAttack) {
                OnAttack = true;
                StartCoroutine(DoDamage(targetStats, attackDelay));
            }
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
		punch.Play();
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
                    // calculate dmg based on str
                    baseDamage += myStats.strengh.GetValue();
                    int finalDamages = baseDamage * (1 - enemyStats.armor.GetValue() / 200);
                    enemyStats.TakeDamage(finalDamages);
                }
            }
        }
    }
}
