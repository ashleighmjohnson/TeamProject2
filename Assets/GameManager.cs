using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject gameOverUI;
    public GameObject hudUI;
    public GameObject blackUI;
    public GameObject gameWinUI;

    public FirstPersonController controller;
    public MenuScript script; 

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        UnityEngine.Debug.Log("gameover / this one");
        hudUI.SetActive(false);
        Time.timeScale = 0f;
        controller.GetComponent<FirstPersonController>().UnlockCursor();
    }

    public void gameWin()
    {
        gameWinUI.SetActive(true);
        UnityEngine.Debug.Log("game Win");
        hudUI.SetActive(false);
        Time.timeScale = 0f;
        controller.GetComponent<FirstPersonController>().UnlockCursor();
    }

  
}
