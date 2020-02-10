using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu_first : MonoBehaviour
{
    public Button ButtonPlay;
    public Button ButtonQuit;
    void Start()
    {
        Button play = ButtonPlay.GetComponent<Button>();
        Button quit = ButtonQuit.GetComponent<Button>();
        play.onClick.AddListener(playGame);
        quit.onClick.AddListener(quitGame);
    }
    void playGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void quitGame () {
        Application.Quit();
    }
void Update()
    {
        
    }
}
