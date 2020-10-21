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
    

     [SerializeField] public Text winText;

    public double fireRate = 9;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
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
            //player shoots here
            float rand = UnityEngine.Random.Range(0, 200);
            //Debug.Log("our random number is " + rand);
            if (rand == fireRate)
            {
                //Debug.Log("inside of firing");
                enemy.GetComponent<Animator>().SetTrigger("Shoot");
                Instantiate(bullet, enemy.position, enemy.rotation); 
            }
            

            if (enemy.position.y <= -5)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0; // stops everything
            }
        }


        // We won the GAME!!!!!
        if (enemyHolder.childCount == 0)
        {
            winText.enabled = true;
            winText.text = "Winner!";
            
            // Change over to the new scene for credits
        }
    }
  
}