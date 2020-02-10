using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class gauge : MonoBehaviour
{
    float percentSlide = 0;
    int currPercent = 0;
    bool up = true;
    public Slider slider;

    void Start()
    {
    }

    void Update()
    {
        // press once gauge chose power 
        if (generalController.MGC.isGaugeOn)
        {
            if (up)
            {
                if (currPercent < 100)
                    currPercent++;
                else
                    up = false;
            }
            else
            {
                if (currPercent > 0)
                    currPercent--;
                else
                    up = true;
            }
            percentSlide = (float)currPercent / 100f;
            slider.value = 1f - percentSlide;
            generalController.MGC.force = 100 - currPercent;
        }
    }
}