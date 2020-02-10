using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu_titile : MonoBehaviour
{
    public GameObject title;
    public Vector3 pos;
    public GameObject title1;
    public Vector3 pos1;
    private bool falche = false;
    private bool vlote = false;
    public GameObject title2;
    public Vector3 pos2;
    public Text subtitle;
    public Color subtitleColor;
    public bool isOn = true;
    public bool courout = false;
    private AudioSource source;
    public AudioClip Generic;
    public Button Game;
    public Button Exit;

    void Start()
    {
        source = GetComponent<AudioSource>();
        pos1 = title1.transform.position;
        pos2 = title2.transform.position;
        subtitleColor = subtitle.color;
        Button onGame = Game.GetComponent<Button>();
        Button onExit = Exit.GetComponent<Button>();
        onGame.onClick.AddListener(LaunchGame);
        onExit.onClick.AddListener(LaunchExit);
        source.PlayOneShot(Generic, 1f);
    }
    void LaunchGame () {
        Debug.Log("LAUNCH GAME");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void LaunchExit() {
        Debug.Log("EXIT");
        Application.Quit();
    }
    void Update()
    {
        Animate();
        if (!courout) {
            StartCoroutine("blink");
        }
    }
    IEnumerator blink() {
        Color tmp = subtitle.color;
        if (isOn) {
            tmp.a = 0f;
            subtitle.color = tmp;
        } else {
            tmp.a = subtitleColor.a;
            subtitle.color = tmp;
        }
        courout = true;
        yield return new WaitForSeconds(Random.Range(0f, 0.5f));
        courout = false;
        isOn = !isOn;
    }
    void Animate () {
        if (!falche)
        {
            title1.transform.position -= new Vector3(0.05f, 0.02f, 0f);
            if (title1.transform.position.x <= (pos1.x - 2))
                falche = true;
        }
        else
        {
            title1.transform.position += new Vector3(0.05f, 0.02f, 0f);
            if (title1.transform.position.x >= (pos1.x + 4))
                falche = false;
        }
        if (!vlote)
        {
            title.transform.position -= new Vector3(0f, 0.04f, 0f);
            title.transform.Rotate(0, 0, .02f, Space.Self);
            if (title.transform.position.y <= (pos1.y - 9))
                vlote = true;
        }
        else
        {
            title.transform.position += new Vector3(0f, 0.04f, 0f);
            title.transform.Rotate(0, 0, -.02f, Space.Self);
            if (title.transform.position.y >= (pos1.y + 9))
                vlote = false;
        }
    }
}
