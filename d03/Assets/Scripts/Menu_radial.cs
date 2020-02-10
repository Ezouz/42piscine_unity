using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_radial : MonoBehaviour
{
    public GameObject MenuRadial;
    public GameObject current;
    public Vector3 screenPos;
    public Button ButtonUpgrade;
    public Button ButtonDowngrade;
    public Button ButtonClose;
    public towerScript TS;
    public bool isOpen;
    void Start()
    {
        Button upgrade = ButtonUpgrade.GetComponent<Button>();
        Button downgrade = ButtonDowngrade.GetComponent<Button>();
        Button close = ButtonClose.GetComponent<Button>();
        upgrade.onClick.AddListener(upgradeTower);
        downgrade.onClick.AddListener(downgradeTower);
        close.onClick.AddListener(closeRadialMenu);
    }
    void upgradeTower () {
        if ((gameManager.gm.playerEnergy - TS.upgrade.GetComponent<towerScript>().energy) >= 0) {
            // Instancie
            GameObject tmp = Instantiate(TS.upgrade, current.transform.position, Quaternion.identity);
            // destroy
            Destroy(current);
            current = tmp;
            refreshTS();
            gameManager.gm.playerEnergy -= current.GetComponent<towerScript>().energy;
        }
    }
    void downgradeTower () {
        int cost;
        if (TS.downgrade != null) {
            GameObject tmp = Instantiate(TS.downgrade, current.transform.position, Quaternion.identity);
            // destroy
            Destroy(current);
            current = tmp;
            refreshTS();
            cost = current.GetComponent<towerScript>().energy / 2;
        } else {
            Destroy(current);
            cost = TS.energy / 2;
            MenuRadial.SetActive(false);
        }

        gameManager.gm.playerEnergy += cost;
    }
    void closeRadialMenu () {
        MenuRadial.SetActive(false);
    }
    void refreshTS () {
        MenuRadial.SetActive(true);
        TS = current.GetComponent<towerScript>();
        if (TS.downgrade != null)
        {
            int cost = TS.downgrade.GetComponent<towerScript>().energy / 2;
            MenuRadial.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text = cost.ToString();
            MenuRadial.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        } else {
            int cost = TS.energy / 2;
            MenuRadial.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text = cost.ToString();
            // MenuRadial.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        } 
        if (TS.upgrade != null) {
            MenuRadial.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = TS.upgrade.GetComponent<towerScript>().energy.ToString();
            MenuRadial.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        } else {
            MenuRadial.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        MenuRadial.transform.GetChild(0).transform.position = screenPos;
        // Debug.Log("current.transform.position " + current.transform.position);
        // Debug.Log("screenPos " + screenPos);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
                Debug.Log("hit.collider.name");
            int layer_mask = LayerMask.GetMask("tower");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, layer_mask);
            if (hit.collider.tag == "tower")
            {
                Debug.Log(hit.collider.gameObject.transform.parent.name);
                current = hit.collider.gameObject.transform.parent.gameObject;
                screenPos = Camera.main.WorldToScreenPoint(current.transform.position);
                // Debug.Log("------- current.transform.position " + current.transform.position);
                // Debug.Log("------- screenPos " + screenPos);
                refreshTS();
                // refreshTS();
            }
        }
    }
}

