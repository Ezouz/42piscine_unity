using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Pause : MonoBehaviour
{
    public GameObject canvas;
    public GameObject subMenu;
    public Button ButtonContinue;
    public Button ButtonQuit;
    public Button ButtonConfirm;
    public Button ButtonReturn;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public bool pause = false;


    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        Button play = ButtonContinue.GetComponent<Button>();
        Button quit = ButtonQuit.GetComponent<Button>();
        Button returnMenu = ButtonReturn.GetComponent<Button>();
        Button escape = ButtonConfirm.GetComponent<Button>();
        play.onClick.AddListener(playGame);
        quit.onClick.AddListener(confirm);
        returnMenu.onClick.AddListener(returnTo);
        escape.onClick.AddListener(quitGame);
    }
    void playGame()
    {
        pause = false;
        canvas.SetActive(false);
        gameManager.gm.pause(false);
    }

    void confirm() {
        subMenu.SetActive(true);
    }

    void returnTo() {
        subMenu.SetActive(false);
    }
    void quitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        if (!pause) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                gameManager.gm.pause(true);
                canvas.SetActive(true);
                pause = true;
            }
        }

    }
}
