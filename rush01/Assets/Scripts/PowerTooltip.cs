using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PowerTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text TTpowerName;
    private Text TTpowerInfo;
    private Image tooltip;
    public string powerName;
    public string powerInfo;
    // public string powerLevel;

    void Start () {
        tooltip = GameObject.Find("TooltipPanel").GetComponent<Image>();
        TTpowerName = GameObject.Find("TpPowerName").GetComponent<Text>(); 
        TTpowerInfo = GameObject.Find("TpPowerInfo").GetComponent<Text>(); 
        TTpowerName.enabled = false;
        TTpowerInfo.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        TTpowerName.text = powerName;
        TTpowerInfo.text = powerInfo;
        TTpowerName.enabled = true;
        TTpowerInfo.enabled = true;
        tooltip.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        TTpowerName.enabled = false;
        TTpowerInfo.enabled = false;
        tooltip.enabled = false;
    }
}
