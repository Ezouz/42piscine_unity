using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class speedManager : MonoBehaviour, IPointerClickHandler
{
    public float speed;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        gameManager.gm.changeSpeed(speed);
    }
}
