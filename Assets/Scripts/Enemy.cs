using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // public Transform enemy; 
    // public float speed;
    //
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("MoveEnemy", 0.05f, 0.3f);        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
    }

    // void MoveEnemy()
    // {
    //     enemy.position += Vector3.right * speed;
    //     
    //     if (enemy.position.x < -10.5 || enemy.position.x > 10.5)
    //     {
    //         speed = -speed; // changes direction
    //         enemy.position += Vector3.down * 0.5f; // moves enemies down
    //         return;
    //     }
    //     
    //
    //     if (enemy.position.y <= -5)
    //     {
    //         GameOver.isPlayerDead = true;
    //         Time.timeScale = 0; // stops everything
    //     }
    // }
}
