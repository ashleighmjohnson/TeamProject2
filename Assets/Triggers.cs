using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameManager gameManager;
    public void OnTriggerEnter(Collider collider)
    {
        UnityEngine.Debug.Log("Collided w game win");
        gameManager.gameWin();
    }
}
