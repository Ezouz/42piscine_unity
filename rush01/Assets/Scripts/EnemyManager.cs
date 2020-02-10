using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    #region Singleton
    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion
    
    public GameObject[] spawners;
    public bool waveCompleted = false;
    public int level = 1;
    public int nbEmptySpawner = 0;
    public int[] spawnerNb; // nombre de spwner par stage

    void Start()
    {
        level = PlayerManager.instance.stats.level;
    }

    public void updateEnemies () {
        foreach (GameObject spawner in spawners)
        {
            spawner.GetComponent<EnemySpawner>().updateEnemies();
        }
    }
    void Update()
    {
        level = PlayerManager.instance.stats.level;
        if (nbEmptySpawner == spawnerNb[GameManager.instance.currentStage]) {
            waveCompleted = true;
            Debug.Log("waveCompleted");
            if (GameManager.instance.currentStage == 0) {
                GameManager.instance.currentStage++;
            } else if (GameManager.instance.currentStage + 1 < GameManager.instance.totalNbOfStages) {
                GameManager.instance.currentStage++;
                GameManager.instance.nextLevel();
            }
        }
    }
}
