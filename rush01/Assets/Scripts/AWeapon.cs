using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWeapon : Interactable
{
    public Rarity rarity;
    new public string name;
    public Type type;
    public int minDmg = 0;
    public int maxDmg = 0;
    public int strModifier = 0;
    public int agiModifier = 0;
    public int constiModifier = 0;
    public float attackSpeed = 0;

    public virtual void Start()
    {
        int rarity_rand = Random.Range(0, 100);

        if (rarity_rand > 90)
        {
            name += "Legendary";
            rarity = Rarity.Legendary;
        }
        else if (rarity_rand >= 70)
        {
            name += "Epic";
            rarity = Rarity.Epic;
        }
        else if (rarity_rand >= 50)
        {
            name += "Rare";
            rarity = Rarity.Rare;
        }
        else 
        {
            name += "Common";
            rarity = Rarity.Common;
        }

        type = (Type)Random.Range(0, 3.99f);
        switch (type)
        {
            case Type.Axe: name += " Axe of "; break;
            case Type.Baton: name += " Baton of "; break;
            case Type.Sign: name += " Sign of "; break;
            case Type.Bat: name += " Bat of "; break;
            default: name+= "lol"; break;
        }

        attackSpeed = Random.Range(0.1f, 2f);

        int qualityModifier = (PlayerManager.instance.level + 1) * ((int)rarity + 1);

        minDmg = Random.Range(1 * qualityModifier, 10 * qualityModifier);
        maxDmg = Random.Range(minDmg, minDmg + 10 * qualityModifier);
        int stat = Random.Range(0,3);
        if (stat == 0)
        {
            strModifier = Random.Range(1 * qualityModifier, 3 * qualityModifier); 
            name += "Strength";
        }
        else if (stat == 1)
        {
            agiModifier = Random.Range(1 * qualityModifier, 3 * qualityModifier); 
            name += "Agility";
        }
        else if (stat == 2)
        {
            constiModifier = Random.Range(1 * qualityModifier, 3 * qualityModifier); 
            name += "Vigor";
        }

        if (gameObject.name != "DONOTREMOVE")
            gameObject.name = name;
        // Debug.Log(name);
        // Debug.Log("Rarity: " + rarity + " Type: " + type +  " minDmg: " + minDmg + " maxDmg: " + maxDmg + " str: " + strModifier + " agi: " + agiModifier + " consti: " + constiModifier + " AS: " + attackSpeed);
    }

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up item: " + name);
        // Add to inventory
        bool wasPickedUp = Inventory.instance.Add(gameObject.GetComponent<RandomWeapon>());
        Debug.Log(this);
        if (wasPickedUp)
            gameObject.SetActive(false);
    }
    public void Use()
    {
         // equip the item 
         EquipmentManager.instance.Equip(gameObject.GetComponent<RandomWeapon>());
         // remove from inventory
         RemoveFromInventory();
     }

     public void RemoveFromInventory()
    {
        Inventory.instance.Remove(gameObject.GetComponent<RandomWeapon>());
    }

}


public enum Rarity { Common, Rare, Epic, Legendary }
public enum Type { Axe, Bat, Baton, Sign, None }