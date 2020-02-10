using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RandomWeapon item;
    public Image icon;
    private Image tooltip;
    private Text tooltipName;
    private Text tooltipDmg;
    private Text tooltipSpeed;
    private Text tooltipStat;
    private Image tooltipIcon;


    void Start () {
        tooltip = GameObject.Find("TooltipPanel").GetComponent<Image>();
        tooltipName = GameObject.Find("TPname").GetComponent<Text>();
        tooltipDmg = GameObject.Find("TPdmg").GetComponent<Text>();
        tooltipSpeed = GameObject.Find("TPspeed").GetComponent<Text>();
        tooltipStat = GameObject.Find("TPstat").GetComponent<Text>();
        tooltipIcon = GameObject.Find("TPicon").GetComponent<Image>();
        tooltip.enabled = false;
        tooltipIcon.enabled = false;
        tooltipName.enabled = false;
        tooltipSpeed.enabled = false;
        tooltipStat.enabled = false;
        tooltipDmg.enabled = false;

    }
    public void AddItem(RandomWeapon newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem ()
    {
        if (item != null)
        {
            item.Use();
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData) {
        if (item == null)
            return;
        tooltipName.text = item.name;
        tooltipDmg.text = "DMG: [" + item.minDmg.ToString() + " - " + item.maxDmg.ToString() + "]";
        tooltipSpeed.text = "AttackSpeed: " + item.attackSpeed.ToString();
        if (item.strModifier > 0)
            tooltipStat.text = "+ " + item.strModifier.ToString() + " STR";
        else if (item.agiModifier > 0)
            tooltipStat.text = "+ " + item.agiModifier.ToString() + " AGI";
        else if (item.constiModifier > 0)
            tooltipStat.text = "+ " + item.constiModifier.ToString() + " VIG";
        tooltipIcon.sprite = item.icon;
        tooltip.enabled = true;
        tooltipIcon.enabled = true;
        tooltipName.enabled = true;
        tooltipSpeed.enabled = true;
        tooltipStat.enabled = true;
        tooltipDmg.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (item == null)
            return;
        tooltip.enabled = false;
        tooltipIcon.enabled = false;
        tooltipName.enabled = false;
        tooltipSpeed.enabled = false;
        tooltipStat.enabled = false;
        tooltipDmg.enabled = false;
    }
}
