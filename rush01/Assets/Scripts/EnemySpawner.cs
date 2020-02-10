using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    private List<GameObject> clones;
    public int nbOfWave = 5;
    public int currentWave = 1;
    int waving = 0;
    public int nbEnemyWave = 1;
    float t;
    float cooldown;
    bool isDead = false;
    bool start = false;

    void Start()
    {
        t = Time.time;
        // spawnOne();
        clones = new List<GameObject>();
        cooldown = Random.Range(3.0f, 6.0f);
    }

    void Update()
    {
        if (transform.childCount == 0 && currentWave == nbOfWave && start) {
            EnemyManager.instance.nbEmptySpawner += 1;
            start = false;
        }
        if (transform.childCount == 0 && currentWave < nbOfWave && waving != 0) {
            currentWave++;
            // nbEnemyWave++;
            cooldown = Random.Range(3.0f, 6.0f);
        }
        if (currentWave != waving) {
            // beguin wave
            if (Time.time - t >= cooldown)
            {
                start = true;
                t = Time.time;
                spawnWave();
                waving = currentWave;
            }
        }
    }

    public void updateEnemies() {
        foreach (GameObject clone in clones)
        {
            if (clone != null)
            {
                clone.transform.parent = gameObject.transform;
                // change enemy level
                upgradeEnemyStats(clone.GetComponent<CharacterStats>());
            }
        }
    }
    void spawnWave()
    {
        Debug.Log("New wave");
        for (int i = 0; i < nbEnemyWave; i++)
        {
            // reorder according to enemies type
            GameObject tmp = Instantiate(enemy[Random.Range(0, 2)], transform);
            clones.Add(tmp);
        }
        updateEnemies();
    }

    void upgradeEnemyStats(CharacterStats eStats) {
        int level = EnemyManager.instance.level;
        eStats.level = level;
        eStats.armor.AddModifier(Random.Range(0, (level < 150) ? level : 150));
        eStats.strengh.AddModifier(Random.Range(0, (level < 150) ? level : 150));
        eStats.agility.AddModifier(Random.Range(0, Mathf.RoundToInt(level / 5)));
        eStats.constitution.AddModifier(Random.Range(0, Mathf.RoundToInt(level / 5)));
        eStats.SetLife(level);
        eStats.XPvalue = Random.Range(1, Mathf.RoundToInt(level / 5));
    }

    void spawnOne()
    {
        clones[0] = Instantiate(enemy[Random.Range(0, 2)], transform);
        clones[0].transform.parent = gameObject.transform;
        upgradeEnemyStats(clones[0].GetComponent<CharacterStats>());
    }
}
