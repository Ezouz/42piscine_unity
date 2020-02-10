using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        stats = player.GetComponent<CharacterStats>();
    }
    #endregion
    public CharacterStats stats;
    public Transform checkpoint;
    public int level;
    public GameObject player;

    public void KillPlayer()
    {
        // invincibility
        // stats.ResetHealth();
        // certain death
        GameManager.instance.resetScene();
    }

    void Start()
    {
        checkpoint = transform;
    }

    void Update()
    {
        // immortality
        // stats.ResetHealth();
    }
}