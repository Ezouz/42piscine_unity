using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// interaction from player to enemy
[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
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