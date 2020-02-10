using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggers : MonoBehaviour
{
    public float increase = 0.5f;
    public bool multiply = false;

    void OnTriggerEnter(Collider obj)  {
        if (multiply)
            GameManager.GM.inSpot = true;
        else
            GameManager.GM.inLight = true;
    }
    void OnTriggerStay(Collider obj)  {
        GameManager.GM.cpt += increase;
        GameManager.GM.cpt = Mathf.Clamp(GameManager.GM.cpt, 0.0f, 100.0f);
    }
    void OnTriggerExit(Collider obj)  {
        if (multiply)
            GameManager.GM.inSpot = false;
        else
            GameManager.GM.inLight = false;
    }
}
