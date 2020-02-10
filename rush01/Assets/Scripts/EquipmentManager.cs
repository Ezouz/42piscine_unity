using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EquipmentManager : MonoBehaviour
{
    private GameObject bat;
    private GameObject baton;
    private GameObject axe;
    private GameObject sign;
    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion


    public RandomWeapon currentWeapon;
    public delegate void OnEquipmentChanged(RandomWeapon newItem, RandomWeapon oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Inventory inventory;

    private void Start()
    {
        bat = GameObject.Find("bat");
        baton = GameObject.Find("baton");
        sign = GameObject.Find("sign");
        axe = GameObject.Find("axe");
        inventory = Inventory.instance;
        currentWeapon = null;
        bat.SetActive(false);
        baton.SetActive(false);
        axe.SetActive(false);
        sign.SetActive(false);
    }

    private void ShowWeapon(Type type) {
        bat.SetActive(false);
        baton.SetActive(false);
        axe.SetActive(false);
        sign.SetActive(false);
        switch (type) {
            case Type.Axe: axe.SetActive(true); break;
            case Type.Baton: baton.SetActive(true); break;
            case Type.Bat: bat.SetActive(true); break;
            case Type.Sign: sign.SetActive(true); break;
            default: break;
        }
    }

    public void Equip(RandomWeapon newItem)
    {
        RandomWeapon oldItem = null;
        if (currentWeapon != null)
        {
            oldItem = currentWeapon;
            inventory.Add(oldItem);
        }
        // trigger changes for stats etc
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentWeapon = newItem;
        ShowWeapon(currentWeapon.type);
    }
    
    public void Unequip()
    {
        if (currentWeapon != null)
        {
            RandomWeapon oldItem = currentWeapon;
            inventory.Add(oldItem);
            // trigger changes for stats etc
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            currentWeapon = null;
            ShowWeapon(Type.None);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Unequip();
        }
    }
}