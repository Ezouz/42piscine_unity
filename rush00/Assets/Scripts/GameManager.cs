using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawner;
    public GameObject Player;
    public bool isWin = false;
    public bool isLose = false;
    void Start()
    {
        // Player = transform.GetComponent<camera>().Player;
    }

    void Update()
    {
        if (Player.transform.GetComponent<PlayerManager>().PV <= 0) {
            isLose = true;
        }
        if (spawner.transform.childCount == 0) {
            isWin = true;
        }
        if (isWin) {
            GameGUI.GGUI.DisplayVictory();
            isWin = false;
        }
        if (isLose)
        {
            GameGUI.GGUI.DisplayLose();
            isLose = false;
        }
    }
}
