using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    // public Transform StartingPoint;
    public GameObject Player;
    public GameObject Clone;
    public GameObject Laser;
    public GameObject Key;
    public GameObject Paper;
    //
    public Slider jauge;
    public GameObject jaugeFillArea;
    public float cpt = 0;
    public float decrease = 0.5f;
    public float decreaseLight = 0.2f;
    public bool inSpot = false;
    public bool inLight = false;
    public bool stoped = false;
    public bool spoted = false;
    public bool reseting = false;
    public bool runs = false;
    //
    private AudioSource source;
    public AudioClip Alarm;
    public AudioClip normal;
    public AudioClip panic;
    public AudioClip footrun;
    public AudioClip lasers;
    //
    public bool hasKey = false;
    public bool hasPaper = false;
    public bool openLaser = false;

    void Awake() {
        if (GM == null)
            GM = this;
    }

    void Start()
    {  
        source = GetComponent<AudioSource>();
        source.PlayOneShot(normal);
    }

    void Update()
    {
        if (inLight || Clone.GetComponent<PlayerMovement>().isRunning) {
            StopCoroutine("decreaseJauge");
            stoped = true;
        } else if (!inSpot || !inLight || !Clone.GetComponent<PlayerMovement>().isRunning) {
            if (stoped) {
                StartCoroutine("decreaseJauge");
            }
        }
        jauge.value = Mathf.Clamp(cpt / 100.0f, 0.0f, 1.0f);
        if (cpt >= 75) {
            if (!spoted) {
                spoted = true;
                source.Stop();
                source.PlayOneShot(panic);
                source.PlayOneShot(Alarm);
            }
        } else {
            if (spoted) {
                source.Stop();
                source.PlayOneShot(normal);
                spoted = false;
            }
        }
        // if player runs
        if (Clone.GetComponent<PlayerMovement>().isRunning) {
            if (!runs) {
                StartCoroutine("runForest");
                runs = true;
            }
            cpt += 0.2f;
            cpt = Mathf.Clamp(cpt, 0.0f, 100.0f);
        }
        // reformat
        if (jauge.value < 0.75f) {
            jaugeFillArea.GetComponent<Image>().color = Color.Lerp(Color.white, Color.white, Mathf.PingPong(Time.time, 0.1f));
        }
        else {
            jaugeFillArea.GetComponent<Image>().color = Color.Lerp(Color.red, Color.red, cpt / 100.0f);
        }
        // reset
        if (cpt == 100) {
            if (!reseting) {
                // Debug.Log("LOSER");
                reseting = true;
                StartCoroutine("resetGame");
            }
        }
        if (hasPaper) {
            // Debug.Log("WINNER");
            hasPaper = false;
            StartCoroutine("resetGame");
        }
        if (openLaser) {
            source.PlayOneShot(lasers);
            openLaser = false;
            Laser.SetActive(false);
        }
    }
    IEnumerator runForest() {
        source.PlayOneShot(footrun);
        yield return new WaitForSeconds(0.3f);
        runs = false;
    }

    IEnumerator resetGame() {
        yield return new WaitForSeconds(1.0f);
        inSpot = false;
        inLight = false;
        stoped = false;
        spoted = false;
        hasKey = false;
        hasPaper = false;
        openLaser = false;
        Laser.SetActive(true);
        Key.SetActive(true);
        Paper.SetActive(true);
        cpt = 0;
        Destroy(Clone);
        Clone = null;
        Clone = Instantiate(Player);
        source.Stop();
        source.PlayOneShot(normal);
        reseting = false;
    }
    
    IEnumerator decreaseJauge() {
        if (cpt > 0f) {
            yield return new WaitForSeconds(decrease);
            cpt -= inLight ? decreaseLight : decrease;
            cpt = Mathf.Clamp(cpt, 0.0f, 100.0f);
        }
        if (cpt <= 0f) {
            stoped = false;
        }
        yield return new WaitForSeconds(decrease);
    }

}
