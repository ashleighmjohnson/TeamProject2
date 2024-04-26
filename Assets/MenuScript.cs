using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuScript : MonoBehaviour
{
    public GameManager gameManager; 
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
        UnityEngine.Debug.Log("Play Button Clicked"); 
    }

    public void OnQuitButton()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Quit Button Clicked");
    }

    public void playAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UnityEngine.Debug.Log("PlayAgain Button Clicked");
        gameManager.playAgainGW(); 
    }
}
