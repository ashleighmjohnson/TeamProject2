using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private EnemyController enemyController;
    void Start() 
    {
        enemyController = GameObject.FindObjectOfType<EnemyController>();
    }
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.CompareTag("Enemy"))
    //     {
    //         print("hit " + collision.gameObject.name);
    //         enemyController.TakeDamage(35);
    //         Destroy(gameObject);
    //     }
    // }
}
