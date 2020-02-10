using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWeapon : AWeapon
{
    public Material[] mat;
    private Image tooltip;
    private Text tooltipName;
    private Text tooltipDmg;
    private Text tooltipSpeed;
    private Text tooltipStat;
    private Image tooltipIcon;
    public Sprite[] icons;
    public Sprite icon;

    public void SetMaterial (Rarity rarity) {
        GetComponent<Renderer>().material = mat[(int)rarity];
    }

    public void SetIcon (Type type) {
       icon = icons[(int)type];
    }

    public override void Start() {
        base.Start();
        tooltip = GameObject.Find("TooltipPanel").GetComponent<Image>();
        tooltipName = GameObject.Find("TPname").GetComponent<Text>();
        tooltipDmg = GameObject.Find("TPdmg").GetComponent<Text>();
        tooltipSpeed = GameObject.Find("TPspeed").GetComponent<Text>();
        tooltipStat = GameObject.Find("TPstat").GetComponent<Text>();
        tooltipIcon = GameObject.Find("TPicon").GetComponent<Image>();
        SetMaterial(rarity);
        SetIcon(type);
        tooltip.enabled = false;
        tooltipIcon.enabled = false;
        tooltipName.enabled = false;
        tooltipSpeed.enabled = false;
        tooltipStat.enabled = false;
        tooltipDmg.enabled = false;
    }

    void OnMouseOver() {
        tooltip.enabled = true;
        tooltipIcon.enabled = true;
        tooltipName.enabled = true;
        tooltipSpeed.enabled = true;
        tooltipStat.enabled = true;
        tooltipDmg.enabled = true;
        tooltipName.text = name;
        tooltipDmg.text = "DMG: [" + minDmg.ToString() + " - " + maxDmg.ToString() + "]";
        tooltipSpeed.text = "AttackSpeed: " + attackSpeed.ToString();
        if (strModifier > 0)
            tooltipStat.text = "+ " + strModifier.ToString() + " STR";
        else if (agiModifier > 0)
            tooltipStat.text = "+ " + agiModifier.ToString() + " AGI";
        else if (constiModifier > 0)
            tooltipStat.text = "+ " + constiModifier.ToString() + " VIG";
        tooltipIcon.sprite = icon;
    }

    void OnMouseExit() {
        tooltip.enabled = false;
        tooltipIcon.enabled = false;
        tooltipName.enabled = false;
        tooltipSpeed.enabled = false;
        tooltipStat.enabled = false;
        tooltipDmg.enabled = false;
    }
}
