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


    public FirstPersonController controller;
    public GameObject gameWinUI;
    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        UnityEngine.Debug.Log("gameover");
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

  

    public void quitGame()
    {
        Application.Quit();
        UnityEngine.Debug.Log("game Quit");
    }


}
