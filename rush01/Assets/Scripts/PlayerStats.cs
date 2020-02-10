using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(RandomWeapon newItem, RandomWeapon oldItem)
    {
        if (newItem != null)
        {
            minDamage.AddModifier(newItem.minDmg);
            maxDamage.AddModifier(newItem.maxDmg);
            strengh.AddModifier(newItem.strModifier);
            agility.AddModifier(newItem.agiModifier);
            constitution.AddModifier(newItem.constiModifier);
            attackSpeed += newItem.attackSpeed;
        }
        if (oldItem != null)
        {
            minDamage.RemoveModifier(oldItem.minDmg);
            maxDamage.RemoveModifier(oldItem.maxDmg);
            strengh.RemoveModifier(oldItem.strModifier);
            agility.RemoveModifier(oldItem.agiModifier);
            constitution.RemoveModifier(oldItem.constiModifier);
            attackSpeed -= oldItem.attackSpeed;
        }
    }

    public override void Die()
    {
        base.Die();
        // add death animation
        CharacterAnimator characterAnimator = GetComponent<CharacterAnimator>();
        characterAnimator.IsDead();
        // Kill the player
        Invoke("rebirth", 3f);
    }
    void rebirth()
    {
        PlayerManager.instance.KillPlayer();
    }
    void Update()
    {

    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "healthPotion")
		{
			GainHealth(10);
			Destroy(other.gameObject);
		}
	}
}
