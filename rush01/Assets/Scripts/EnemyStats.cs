using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private RandomWeapon loot;

    void Start() {
        loot = Resources.Load<RandomWeapon>("Loot");
        // loot = GameObject.Find("DONOTREMOVE");
    }
    public override void Die()
    {

        base.Die();
        GetComponent<EnemyController>().isDead = true;
        // add death animation
        CharacterAnimator characterAnimator = GetComponent<CharacterAnimator>();
        characterAnimator.IsDead();
        // destroy GameObject
        float lootRand = Random.Range(0, 3.0f);
        if (lootRand > 1.0f)
        {
            Debug.Log("GENERATED LOOT");
            Instantiate(loot, transform.position, Quaternion.identity);
        }
        Invoke("destroyGM", 5f);
    }
    void destroyGM() {
        Destroy(gameObject);
    }
}