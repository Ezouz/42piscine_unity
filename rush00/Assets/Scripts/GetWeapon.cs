using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    PlayerManager PM;

    void Start()
    {
        PM = transform.GetComponentInParent<PlayerManager>();
    }
    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.tag == "weapon")
        {
            // recuperer arme
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!PM.isArmed)
                {
                    PM.weaponToBody = Instantiate(obj.gameObject.GetComponent<Weapon>().toBody, PM.transform);
                    PM.weaponToBody.GetComponent<Weapon2body>().ammo = obj.gameObject.GetComponent<Weapon>().ammo;
                    PM.weaponToBody.GetComponent<Weapon2body>().armeBlanche = obj.GetComponent<Weapon>().armeBlanche;
                    PM.weaponToBody.GetComponent<Weapon2body>().distance = obj.GetComponent<Weapon>().distance;
                    Destroy(obj.gameObject);
                    PM.isArmed = true;
                    PM.source.PlayOneShot(PM.Reload, 1f);
                    GameGUI.GGUI.CurrentWeapon = PM.weaponToBody.GetComponent<Weapon2body>();
                }
            }
        }
    }
    void Update()
    {
        
    }
}
