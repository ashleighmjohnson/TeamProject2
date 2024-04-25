using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorKeyController : MonoBehaviour
{
    // The name of the scene you want to load
    public string sceneToLoad;

    // Reference to the elevator key GameObject
    public GameObject elevatorKey;

    public GameObject enemies;


    void Start()
    {
        
      //  enemies = GameObject.Find("Enemy");
      //  if(enemies == null )
      //  {
       //     Debug.Log("enemies null");
       // }
    }
    void Update()
    {
      //  ActivateElevatorKey();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          SceneManager.LoadScene(sceneToLoad);
        }
    }
   /* public void ActivateElevatorKey()
    {

        int enemyNum = enemies.transform.childCount;

        Debug.Log(enemyNum);

        if (enemyNum <= 0)
        {
            Debug.Log("WORKING");
            elevatorKey.SetActive(true);
        } else
            {
                Debug.Log("NOT WORKING");
            }
        
    }
   */
}

