using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// interaction from player to enemy
[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    public CharacterStats myStats;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    void OnDestroy()
    {
        Debug.Log("Level Up");
        playerManager.stats.LevelUp(myStats.XPvalue);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "enemyHurtZone")
		{
			myStats.TakeDamage(other.gameObject.GetComponent<EnemyHurtZone>().damage);
		}
	}

    public override void Interact()
    {
        base.Interact();
        // Attack the enemy
        // CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        // if (playerCombat != null)
        // {
        //     playerCombat.Attack(myStats);
        // }
    }
}
