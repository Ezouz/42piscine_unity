using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerManager : MonoBehaviour
{
    public static playerManager PM;
    public string mapName;
    public GameObject UIplayer;

    void Awake () {
        if (!PM) {
            PM = this;
        }
    }

    void UpdatePlayerUI()
    {
        UIplayer.gameObject.transform.GetChild(0).GetComponentInChildren<UnityEngine.UI.Text>().text = gameManager.gm.playerHp.ToString();
        UIplayer.gameObject.transform.GetChild(1).GetComponentInChildren<UnityEngine.UI.Text>().text = gameManager.gm.playerEnergy.ToString();
    }
    void Start()
    {
        UIplayer.gameObject.transform.GetChild(0).GetComponentInChildren<UnityEngine.UI.Text>().text = gameManager.gm.playerMaxHp.ToString(); 
        UIplayer.gameObject.transform.GetChild(1).GetComponentInChildren<UnityEngine.UI.Text>().text = gameManager.gm.playerStartEnergy.ToString();
    }

    void Update()
    {
        UpdatePlayerUI();
    }
}
