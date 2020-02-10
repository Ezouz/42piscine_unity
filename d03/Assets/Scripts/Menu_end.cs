using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu_end : MonoBehaviour
{
    public bool end = false;
    public bool win = false;
    public GameObject Spawner;
    public GameObject EndCanvas;
    public GameObject MenuVictory;
    public GameObject MenuLose;
    public Button ButtonRestart;
    public Button ButtonNext;
    public string grade;
    void Start()
    {
        Button restart = ButtonRestart.GetComponent<Button>();
        Button next = ButtonNext.GetComponent<Button>();
        restart.onClick.AddListener(restartGame);
        next.onClick.AddListener(nextLevel);
        Spawner = GameObject.FindGameObjectsWithTag("spawner")[0];
    }

    void SetGrade () {
        int nrj = gameManager.gm.playerEnergy / 500;
        int tmp = 0;
        if (gameManager.gm.playerHp <= 4) {
            tmp += 1; 
        } else if (gameManager.gm.playerHp > 4 && gameManager.gm.playerHp <= 8) {
            tmp += 2; 
        } else if (gameManager.gm.playerHp > 8 && gameManager.gm.playerHp <= 12) {
            tmp += 3; 
        } else if (gameManager.gm.playerHp > 12 && gameManager.gm.playerHp <= 16) {
            tmp += 4; 
        } else if (gameManager.gm.playerHp > 16 && gameManager.gm.playerHp <= 20) {
            tmp += 5; 
        } 
        if (nrj <= 4) {
            tmp += 1; 
        } else if (nrj > 4 && nrj <= 8) {
            tmp += 2; 
        } else if (nrj > 8 && nrj <= 12) {
            tmp += 3; 
        } else if (nrj > 12 && nrj <= 16) {
            tmp += 4; 
        } else if (nrj > 16) {
            tmp += 5;
        }
        if (tmp <= 2) {
            grade = "Zero"; 
        } else if (tmp > 2 && tmp <= 4) {
            grade = "Débilos"; 
        } else if (tmp > 4 && tmp <= 6) {
            grade = "Casse Coup"; 
        } else if (tmp > 6 && tmp <= 8) {
            grade = "Brute"; 
        } else if (tmp > 8) {
            grade = "As";
        }
    }
    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Update()
    {
        if (!end) {
            // win
            if (gameManager.gm.lastWave && Spawner.gameObject.transform.childCount == 0) {
                SetGrade();
                MenuVictory.SetActive(true);
                MenuVictory.transform.GetChild(2).GetComponent<Text>().text = gameManager.gm.score.ToString();
                MenuVictory.transform.GetChild(4).GetComponent<Text>().text = grade;
                EndCanvas.SetActive(true);
                end = true;
            }
            // lose
            if (gameManager.gm.playerHp <= 0) {
                Debug.Log("LOSER");
                SetGrade();
                MenuLose.SetActive(true);
                MenuLose.transform.GetChild(2).GetComponent<Text>().text = gameManager.gm.score.ToString();
                MenuLose.transform.GetChild(4).GetComponent<Text>().text = grade;
                EndCanvas.SetActive(true);
                end = true;
            }
        }
    }
}
