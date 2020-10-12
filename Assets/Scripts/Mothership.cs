using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Mothership : MonoBehaviour
{
    public Transform enemyHolder; 
    public GameObject bullet;
    public float speed; 
  
    public Transform shottingOffset;

     [SerializeField] public Text winText;

    public double fireRate = 0.997;
    
    // Start is called before the first frame update
    void Start()
    {
        // winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;
        
        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -10.5 || enemy.position.x > 10.5)
            {
                speed = -speed; // changes direction
                enemyHolder.position += Vector3.down * 0.5f; // moves enemies down
                return;
            }
            

            if (enemy.position.y <= -5)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0; // stops everything
            }
        }

        // increase the speed; 
        // if (enemyHolder.childCount % 6 == 0)
        // {
        //     speed *= 2;
        //     enemyHolder.position += Vector3.right * speed; 
        // }

        // if (enemyHolder.childCount == 1)
        // {
        //     CancelInvoke();
        //     InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        // }
        
        
        // We won the GAME!!!!!
        if (enemyHolder.childCount == 0)
        {
            winText.enabled = true;
            winText.text = "Winner!";
        }
    }
    // get the enemy to shoot
    // void FixedUpdate()
    // {
    //     bullet.transform.position += Vector3.up * -speed;
    //     if (bullet.transform.position.y <= -10)
    //     {
    //         Destroy(bullet.gameObject);
    //     }
    // }

    // private void OnCollisionEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         Destroy(other.gameObject);    // destory the player
    //         Destroy(gameObject);        // destroy bullet
    //         GameOver.isPlayerDead = true; 
    //     }
    //     else if (other.tag == "Base")
    //     {
    //         GameObject playerBase = other.gameObject;
    //         BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
    //         baseHealth.health -= 1;
    //         Destroy(gameObject);
    //     }
    // }
}