using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> team;
    
    public CityHall HcityHall;
    public CityHall OcityHall;
    public bool HCH = true;
    public bool OCH = true;
    public bool win = false;

    void Awake() {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) { // left button
            List<GameObject> tmp = new List<GameObject>();
            team = tmp;
        }
        if (Input.GetMouseButtonDown(0)) { // left button
                
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null) {
                if (hit.collider.gameObject.tag == "team" && hit.collider.gameObject.layer != 10) {
                    PlayerMovement mate = hit.collider.gameObject.GetComponent<PlayerMovement>();
                    if (Input.GetKey(KeyCode.LeftControl)) {
                        if (!mate.inTeam) {
                            team.Add(hit.collider.gameObject);
                            mate.inTeam = true;
                        } else {
                            team.Remove(hit.collider.gameObject);
                        }
                    } else { // on clean selection et on met que celui la
                        List<GameObject> tmp = new List<GameObject>();
                        tmp.Add(hit.collider.gameObject);
                        mate.inTeam = true;
                        team = tmp;
                    }
                } else {
                    foreach (GameObject mate in team)
                    {
                        if (mate) {
                            mate.GetComponent<PlayerMovement>().moveOrder = true;
                            if (hit.collider.transform.tag == "orc") {
                                mate.GetComponent<PlayerMovement>().enemy = hit.collider.gameObject;
                            } else {
                                mate.GetComponent<PlayerMovement>().targetPosition = hit.collider.gameObject.transform.position;
                                if (mate.GetComponent<PlayerMovement>().enemy) {
                                    mate.GetComponent<PlayerMovement>().enemy = null;
                                }
                            }
                        }
                    }
                }
            }
        }

        if (win) {
            if (!HCH) {
                Debug.Log("The Orc Team wins.");
            }
            if (!OCH) {
                Debug.Log("The Human Team wins.");
            }
            win = false;
        }
        if (!HCH || !OCH)
            win = true;
    }
}