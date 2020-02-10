using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        // EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    // void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    // {
    //     if (newItem != null)
    //     {
    //         //armor.addModifier(newItem.armorModifier);
    //         damage.AddModifier(newItem.damageModifier);
    //     }
    //     if (oldItem != null)
    //     {
    //         //armor.addModifier(newItem.armorModifier);
    //         damage.RemoveModifier(oldItem.damageModifier);
    //     }
    // }

    public override void Die()
    {
        base.Die();
        // add death animation
        // CharacterAnimator characterAnimator = GetComponent<CharacterAnimator>();
        // characterAnimator.IsDead();
        // Kill the player
        // Invoke("rebirth", 3f);
    }
    void rebirth()
    {
        PlayerManager.instance.KillPlayer();
    }
    void Update()
    {

    }
}