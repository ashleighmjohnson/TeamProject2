using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuScript : MonoBehaviour
{
    public GameManager gameManage; 

    public void OnPlayMainMenuButton()
    {
        SceneManager.LoadScene(0);
        UnityEngine.Debug.Log("Play Button Clicked");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void playAgain()
    {
        UnityEngine.Debug.Log("game manager play again");
        SceneManager.LoadScene("Basement");
    }

    public void quitGame()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Quit Button Clicked - GL");
        SceneManager.LoadScene(0);

    }
}
