using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // health
    public static PlayerHealth instance;
    public Text healthTxt;
    int health = 200;

    // timer
    public float targetTime = 180.0f;
    public Text timerTxt;

    // gamemanager
    public GameObject gameManager;



    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        // timer
        if (targetTime > 0)
        {
            targetTime -= Time.deltaTime;
            timerTxt.text = "Timer: " + targetTime.ToString();
        }
        else
        {
            UnityEngine.Debug.Log("Game Over");
            targetTime = 0;
        }
    }


    void Start()
    {
        // health hud 
        healthTxt.text = "Health: " + health.ToString();
    }

    public void runningHealthTotal(int damage)
    {
        // damage by enemy to player
        health -= damage;
        healthTxt.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            healthTxt.text = "Game Over.";
            gameManager.GetComponent<GameManager>().gameOver();
        }
    }


}