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
        instance = this;
    }
    #endregion
    public CharacterStats stats;
    public Transform checkpoint;

    public GameObject player;

    public void KillPlayer()
    {
        // // stats
        // stats.ResetHealth();
        // // transform
        // transform.position = checkpoint.position;
        // transform.rotation = checkpoint.rotation;
        // UNDEAD Anim
        // if not
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        stats = player.GetComponent<CharacterStats>();
        checkpoint = transform;
    }

    void Update()
    {
        // immortality
        stats.ResetHealth();
    }
}