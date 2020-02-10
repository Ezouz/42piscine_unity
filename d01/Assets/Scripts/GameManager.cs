using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public playerScript_ex01 Thomas;
    public playerScript_ex01 John;
    public playerScript_ex01 Claire;
    public bool inZone = false;
    public string playerInZone = "";
    public bool levelDone = false;
    public string levelName = "";
    public string nextScene = "";

    void Awake ()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "ex01")
            levelName = "LEVEL 1";
        else if (SceneManager.GetActiveScene().name == "ex02")
            levelName = "LEVEL 2";
        else if (SceneManager.GetActiveScene().name == "ex03")
            levelName = "LEVEL 3";
        else if (SceneManager.GetActiveScene().name == "ex04")
            levelName = "LEVEL 4";

    }

    void passScene () {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= (SceneManager.sceneCountInBuildSettings))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - (SceneManager.sceneCountInBuildSettings - 1));
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (playerInZone == "Thomas") {
            Thomas.isReady = inZone;
            playerInZone = "";
        } else if (playerInZone == "John") {
            John.isReady = inZone;
            playerInZone = "";
        } else if (playerInZone == "Claire") {
            Claire.isReady = inZone;
            playerInZone = "";
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            passScene();
        }
        if (Thomas.isReady && John.isReady && Claire.isReady && !levelDone) {
            Thomas.actif = false;
            John.actif = false;
            Claire.actif = false;
            levelDone = true;
            Debug.Log("CONGRATULATION " + levelName + " DONE!");
            passScene();
        }
    }
}
