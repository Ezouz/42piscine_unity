using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public AudioSource source;
    public AudioClip musicNormal;
    public AudioClip musicPanic;
    public AudioClip riffleSound;
    public AudioClip missileSoundHit;
    public AudioClip missileSound;
    public GameObject enemies;

    void Awake () {
        if (GM == null) {
            GM = this;
        }
    }
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(musicNormal);
    }

    void Update()
    {
        // Lose
        // if (PlayerManager.PM.PV <= 0) {

        // }
        // Win
        // if (enemies.gameObject.childCount == 0) {

        // }
        
    }
}
