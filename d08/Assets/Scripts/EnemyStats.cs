using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        GetComponent<EnemyController>().isDead = true;
        // add death animation
        CharacterAnimator characterAnimator = GetComponent<CharacterAnimator>();
        characterAnimator.IsDead();
        // destroy GameObject
        Invoke("destroyGM", 5f);
    }
    void destroyGM() {
        Destroy(gameObject);
    }
}