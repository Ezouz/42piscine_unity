using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerManager : MonoBehaviour
{
    public string map;
    public int wait;
    public int damage;
    public int range;
    public int energy;
    public bool fly;
    public Sprite flysprite;
    public Sprite noflysprite;
    public Transform UItower;
    public GameObject prefab;
    private dragTower drager;
    private Color initCol;

    void UpdateTowerUI () {
        UItower.gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<Text>().text = wait.ToString();
        UItower.gameObject.transform.GetChild(1).GetChild(0).GetComponentInChildren<Text>().text = damage.ToString();
        UItower.gameObject.transform.GetChild(2).GetChild(0).GetComponentInChildren<Text>().text = range.ToString();
        UItower.gameObject.transform.GetChild(3).GetChild(0).GetComponentInChildren<Text>().text = energy.ToString();
        UItower.gameObject.transform.GetChild(4).GetComponent<Image>().sprite = fly ? flysprite : noflysprite;
    }
    void Start()
    {
        initCol = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color;
        UpdateTowerUI();
        drager = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<dragTower>();
    }

    void Update()
    {
        if (drager.ADD) {
            if ((gameManager.gm.playerEnergy - energy) >= 0) {
                GameObject tmp = Instantiate(prefab, drager.drop, Quaternion.identity);
                if (map == "") {
                    drager.tile.tag = "tile";
                }   
                gameManager.gm.playerEnergy -= energy;
            }
            drager.drop = Vector3.zero;
            drager.tile = null;
            drager.ADD = false;
        }
        if ((gameManager.gm.playerEnergy - energy) < 0) {
            drager.block = true;
            this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.black; ;
        } else {
            drager.block = false;
            this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = initCol; ;
        }



    }
}
