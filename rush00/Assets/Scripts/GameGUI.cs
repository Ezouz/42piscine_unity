using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour
{
    public static GameGUI GGUI;
    public GameObject MenuVictory;
    public GameObject MenuLose;
    public Button ButtonRestart;
    public Button ButtonNext;
    public Text weapon;
    public Text type;
    public Text ammo;
    public Weapon2body CurrentWeapon;
    private AudioSource source;
    public AudioClip Win;
    public AudioClip Lose;
    public AudioClip BO;

    void Awake () {
        if (GGUI == null) {
            GGUI = this;
        }
    }
    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(BO, 1f);
        Button restart = ButtonRestart.GetComponent<Button>();
        Button next = ButtonNext.GetComponent<Button>();
        restart.onClick.AddListener(restartGame);
        next.onClick.AddListener(nextLevel);
        CurrentWeapon = null;
    }
    void Update () {
        if (CurrentWeapon != null) {
            weapon.text = CurrentWeapon.weaponName;
            type.text = CurrentWeapon.type;
            ammo.text = CurrentWeapon.ammo.ToString();
        } else {
            weapon.text = "Unarmed";
            type.text = "";
            ammo.text = "";
        }
    }
    public void DisplayVictory () {
        source.PlayOneShot(Win, 1f);
        MenuVictory.SetActive(true);
    }
    public void DisplayLose()
    {
        source.PlayOneShot(Lose, 1f);
        MenuLose.SetActive(true);
    }
}
