using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion
    // ui
    bool StatsUIisOpen = false;
    // SCENES
    public int currentStage = 0;
    public int totalNbOfStages = 4;
    public Transform[] checkpoint;
    // SAVES
    // save at checkpoint
    // player charachterStats
    // player inventory

    void Start ()
    {
        currentStage = 0;
        // first save pref
    }

    public void resetScene () {
        // Checkpoint
        PlayerManager.instance.player.transform.GetComponent<PlayerMotor>().agent.enabled = false;
        PlayerManager.instance.player.transform.position = checkpoint[currentStage].position;
        PlayerManager.instance.player.transform.GetComponent<PlayerMotor>().agent.enabled = true;
        // reset health
        PlayerManager.instance.stats.ResetHealth();
        PlayerManager.instance.player.gameObject.GetComponent<CharacterAnimator>().UnDead();
        // remove some XP
        PlayerManager.instance.stats.XP = 0;
    }

    public void nextLevel () {
        if (currentStage < totalNbOfStages) {
            // save player state
            PlayerManager.instance.player.transform.GetComponent<PlayerMotor>().agent.enabled = false;
            PlayerManager.instance.player.transform.position = checkpoint[currentStage].position;
            PlayerManager.instance.player.transform.GetComponent<PlayerMotor>().agent.enabled = true;
        } else {
            PlayerManager.instance.player.transform.position = checkpoint[0].position;
        }
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            // PlayerManager.instance.stats.level += 1;
            int txp = PlayerManager.instance.stats.nlXP;
            PlayerManager.instance.stats.LevelUp(txp);
            EnemyManager.instance.updateEnemies();
        }
        if (Input.GetKey(KeyCode.Tab)) {
            StatsUI.instance.StatIsOpen = true;
            StatsUIisOpen = true;
        } else {
            if (StatsUIisOpen) {
                StatsUI.instance.StatIsOpen = false;
                StatsUIisOpen = false;
            }
        }
    }
}
