using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreUi : MonoBehaviour
{
    public GameObject roadshit;
    public GameObject score;
    public GameObject finalscore;
    public GameObject trounum;
    public GameObject par;
    public GameObject nbc;
    public GameObject rank;
    // current
    public GameObject current;
    public GameObject trounumCur;
    public GameObject parCur;
    public GameObject nbcCur;
    private bool shut = true;
    private bool shutCur = false;

    void Start()
    {
    }
    void displayCurrent() {
        trounumCur.GetComponent<Text>().text = (GameManager.GM.currentTrou + 1).ToString();
        parCur.GetComponent<Text>().text = GameManager.GM.par[GameManager.GM.currentTrou].ToString();
        nbcCur.GetComponent<Text>().text = GameManager.GM.score[GameManager.GM.currentTrou].ToString();
    }
    public void displayScoreTrou(int trou) {
        roadshit.SetActive(true);
        score.SetActive(true);
        finalscore.SetActive(false);
        trounum.GetComponent<Text>().text = (trou + 1).ToString();
        nbc.GetComponent<Text>().text = GameManager.GM.score[trou].ToString();
        par.GetComponent<Text>().text = GameManager.GM.par[trou].ToString();
        if (GameManager.GM.next) {
            rank.GetComponent<Text>().text = scoreGenerator.SG.moulinette(GameManager.GM.score[trou], GameManager.GM.par[trou]);
        }
    }
    public void displayScoreTotal() {
        int scoreTotal = GameManager.GM.score[0] + GameManager.GM.score[1] + GameManager.GM.score[2];
        int parTotal = GameManager.GM.par[0] + GameManager.GM.par[1] + GameManager.GM.par[2];
        roadshit.SetActive(true);
        score.SetActive(false);
        finalscore.SetActive(true);
        nbc.GetComponent<Text>().text = scoreTotal.ToString();
        par.GetComponent<Text>().text = parTotal.ToString();
        rank.GetComponent<Text>().text = scoreGenerator.SG.moulinette(scoreTotal, parTotal);
    }
    void shutScore() {
        roadshit.SetActive(false);
    }

    // interface trou en cour et nbre de coups
    void Update()
    {
        if (GameManager.GM.next) {
            // si final screen
            if (Input.GetKey("1")) {
                displayScoreTrou(0);
            }
            if (Input.GetKey("2")) {
                displayScoreTrou(1);
            }
            if (Input.GetKey("3")) {
                displayScoreTrou(2);
            }
            if (Input.GetKey("4")) {
                displayScoreTotal();
            }
            if (shutCur) {
                current.SetActive(false);
                shutCur = false;
            }
        } else {
            // display and update current
            displayCurrent();
            if (Input.GetKey(KeyCode.Tab)) {
                if (GameManager.GM.score[GameManager.GM.currentTrou] < 3) {
                    displayScoreTrou(GameManager.GM.currentTrou);
                    shut = false;
                }
            } else {
                shut = true;
            }
            if (shut)
                roadshit.SetActive(false);
        }
        if (!shutCur) {
            shutCur = true;
        }
    }
}
